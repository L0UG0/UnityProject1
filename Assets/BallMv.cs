using UnityEngine;

public class BallMv : MonoBehaviour
{
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cylinder250")
        {
            Score.score += 250;
        }
        if (other.gameObject.tag == "Cylinder500")
        {
            Score.score += 500;
        }
        if (other.gameObject.tag == "Koniec")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    void Update()
    {
        
    }
}
