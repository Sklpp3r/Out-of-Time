using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {

            CoinManager.Instance.CollectCoin();
            
            Destroy(gameObject);
        }
    }
}