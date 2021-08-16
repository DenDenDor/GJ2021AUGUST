using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
  [SerializeField]  private float _distance_between_hearts;  
   [SerializeField]  private float _amount_of_hearts;
   [SerializeField] private Heart _heart;
   [SerializeField] private Transform _current_position;
   private float _current_amount_of_hearts;
   [SerializeField] private Transform _spawnpoint;
   private float _directionOfCreating;
  [SerializeField] private bool _isOnRight;
  [SerializeField] private List<Heart> _hearts = new List<Heart>() ;
   private float _number_of_hearts;
   private void Start()
    {
        ChangeDirection();
       SetAmountOfHearts();
   }
   private void ChangeDirection()
   {
       _directionOfCreating = _isOnRight ? 1 : -1;  
   }
   private Vector3 ChangePosition()
   {
      return _current_position.position = new Vector3((_distance_between_hearts  + _current_position.position.x )*_directionOfCreating, _current_position.position.y,_current_position.position.z) ;
   }
   private void SetAmountOfHearts()
   {
       _current_amount_of_hearts = _amount_of_hearts;
   }
   private void Update() {
            if(Input.GetKeyDown(KeyCode.Space) && _amount_of_hearts < _current_amount_of_hearts)
       {
           _hearts.Reverse();
           for (int i = 0; i < _amount_of_hearts -1; i++)
           {
              Heart heart = null;
             heart = _hearts[-i];
            _hearts.Remove(heart);
            Destroy(heart.gameObject);
           }
           
       }
       if (_current_amount_of_hearts < _amount_of_hearts && Input.GetMouseButtonDown(0))
       {
           _number_of_hearts = _amount_of_hearts - _current_amount_of_hearts;
           for (int i = 0; i < _number_of_hearts; i++)
           {
               ChangeDirection();
             CreateHeart();
              SetAmountOfHearts();   
           }
        
       }
   
   }
   private void DestroyHearts()
   {
           
   }
   private void CreateHeart()
   {
        Heart heart = Instantiate(_heart, ChangePosition(), Quaternion.identity);
        heart.transform.SetParent(_spawnpoint, true);
         _hearts.Add(heart);
        
   }
}
