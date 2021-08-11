
using UnityEngine;

public class Zombie : MonoBehaviour, IEnemy
{
     [SerializeField] private Player _player;

    private void Update() {
       Move();
   }

    public void Attack()
    {
        Debug.Log("Attack");
    }

    public int Damage(int _damage)
    {
        return _damage + 1;
    }

    public int Health(int _health)
    {
       return _health + 2;
    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, Speed(5));
        if (Vector2.Distance(_player.transform.position, transform.position) < 0.5f)
        {
            Attack();
        }
    }

    public int Speed(int _speed)
    {
        return _speed - 2;
    }

    public void SetPlayer(Player _character)
    {
        _player = _character;
    }
}
