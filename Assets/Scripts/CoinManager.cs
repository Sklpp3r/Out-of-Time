using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Singleton örneği

    private int totalCoins; // Oyundaki toplam coin sayısı
    private int collectedCoins; // Toplanan coin sayısı

    void Awake()
    {
        // Singleton oluştur
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Oyundaki tüm coinleri bul ve toplam coin sayısını ayarla
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        collectedCoins = 0;
    }

    public void CollectCoin()
    {
        collectedCoins++; // Coin toplandı
        Debug.Log($"Coin toplandı! Toplam: {collectedCoins}/{totalCoins}");

        // Tüm coinler toplandıysa kapıyı aç
        if (collectedCoins >= totalCoins)
        {
            DoorManager.Instance.OpenDoor();
        }
    }
}

