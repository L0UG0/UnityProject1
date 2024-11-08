using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static bool czykoniec = false;
    public Text scoreText;
    
    void Update()
    {
        scoreText.text = "Twój wynik: " + score.ToString();
        if (czykoniec)
        {
            scoreText.text = "Koniec gry! Twój wynik to: " + score;
        }
    }
}
