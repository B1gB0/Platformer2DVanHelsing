using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Die(collision);
        }
    }

    private void Die(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        enemy.gameObject.SetActive(false);
    }
}