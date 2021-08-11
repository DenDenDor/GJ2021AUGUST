
using UnityEngine;

public class Ghost : MonoBehaviour, IEnemy
{
 [ SerializeField]  private Player _player;

    private void Update() {
       Move();
   }

    public void Attack()
    {
        Debug.Log("Attack player");
        Damage(13);
        Health(2);
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
        transform.Translate(Vector3.right * Speed(2));
        if (Vector2.Distance(_player.transform.position, transform.position) < 0.5f)
        {
            Attack();
        }
    }

    public int Speed(int _speed)
    {
        return _speed + 4;
    }

    public void SetPlayer(Player _character)
    {
        _player = _character;
    }
}
