using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _money = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            player.AddMoney(_money);

            gameObject.SetActive(false);
        }
    }
}
