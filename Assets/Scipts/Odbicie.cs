using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odbicie : MonoBehaviour
{
    public float explosionStrength = 50.0f;
    void Start()
    {
        
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.rigidbody.AddExplosionForce(explosionStrength, transform.position, 5.0f);
        }
    }
}
