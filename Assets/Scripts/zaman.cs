using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class zaman : MonoBehaviour
{
    public float countdownTime = 30f;
    public TextMeshProUGUI countdownText;
    private bool isTimerRunning = false;

    void Start()
    {
        StartCountdown();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (countdownTime > 0)
            {
                countdownTime -= Time.deltaTime;
                countdownText.text = Mathf.CeilToInt(countdownTime).ToString();
            }
            else
            {
                countdownTime = 0;
                isTimerRunning = false;
                OnTimeUp();
            }
        }
    }
    public void StartCountdown()
    {
        isTimerRunning = true;
        countdownTime = 30f;
    }

    private void OnTimeUp()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}