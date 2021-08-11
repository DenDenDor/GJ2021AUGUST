
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
        {
            Debug.Log(enemy);
        }
    }
}
