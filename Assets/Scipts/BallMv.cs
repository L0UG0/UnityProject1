using UnityEngine;

public class BallMv : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 pozycjaStartowa;
    public Material podswietlony;
    public Material normalnyzielony;
    public Material normalnyzolty;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pozycjaStartowa = transform.position;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cylinder250")
        {
            Score.score += 250;
            other.gameObject.GetComponent<Renderer>().material = podswietlony;
        }
        if (other.gameObject.tag == "Cylinder500")
        {
            Score.score += 500;
            other.gameObject.GetComponent<Renderer>().material = podswietlony;
        }
        if (other.gameObject.tag == "Koniec")
        {
            iloscprob.iloscProb -= 1;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            if (iloscprob.iloscProb == 0)
            {
                Score.czykoniec = true;
            }
            else
            {
                transform.position = pozycjaStartowa;
                
            }
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Cylinder500")
        {
            other.gameObject.GetComponent<Renderer>().material = normalnyzielony;
        }
        if (other.gameObject.tag == "Cylinder250")
        {
            other.gameObject.GetComponent<Renderer>().material = normalnyzolty;
        }
    }
    void Update()
    {
        
    }
}
