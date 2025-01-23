using UnityEngine;

public class TimeBoostPickup : MonoBehaviour
{
    public float timeBonus = 10f;
    public GameObject pickupEffect;
    public zaman zaman;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddTimeBonus();

            Destroy(gameObject);
        }
    }

    private void AddTimeBonus()
    {
        if (zaman != null)
        {
            zaman.countdownTime += timeBonus;
        }
        else
        {
            Debug.LogWarning("CountdownTimerTMP scriptine referans bağlanmamış!");
        }
    }
}

