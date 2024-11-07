using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;
    
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
