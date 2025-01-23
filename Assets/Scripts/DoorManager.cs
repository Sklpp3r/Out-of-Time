using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager Instance;

    private bool isDoorOpen = false;

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

    public void OpenDoor()
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            Debug.Log("Tüm coinler toplandı! Kapı açılıyor...");
            
            Destroy(gameObject);

        }
    }
}