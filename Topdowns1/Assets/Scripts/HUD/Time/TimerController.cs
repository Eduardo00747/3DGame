using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 60f; // Tempo inicial em segundos
    public TMP_Text timerText; // Referência ao objeto de texto

    void Start()
    {
        timerText.text = " " + timeRemaining.ToString("F1"); // Define o valor inicial do cronômetro
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Subtrai o tempo que passou desde o último quadro
            timerText.text = " " + timeRemaining.ToString("F1"); // Atualiza o texto do cronômetro
        }
        else
        {
            timeRemaining = 0; // Define o tempo restante como zero
            timerText.text = "Game Over!"; // Exibe uma mensagem de "Game Over"
        }
    }
}
