using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 60f; // Tempo inicial em segundos
    public TMP_Text timerText; // Refer�ncia ao objeto de texto

    void Start()
    {
        timerText.text = " " + timeRemaining.ToString("F1"); // Define o valor inicial do cron�metro
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Subtrai o tempo que passou desde o �ltimo quadro
            timerText.text = " " + timeRemaining.ToString("F1"); // Atualiza o texto do cron�metro
        }
        else
        {
            timeRemaining = 0; // Define o tempo restante como zero
            timerText.text = "Game Over!"; // Exibe uma mensagem de "Game Over"
        }
    }
}
