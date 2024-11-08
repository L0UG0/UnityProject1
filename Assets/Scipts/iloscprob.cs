using UnityEngine;
using UnityEngine.UI;

public class iloscprob : MonoBehaviour
{
    public Text iloscProbText;
    public static int iloscProb = 2;
    void Update()
    {
        iloscProbText.text = "Pozostałe próby: " + iloscProb.ToString();
    }
}
