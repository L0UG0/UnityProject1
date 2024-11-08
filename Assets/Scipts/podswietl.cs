using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podswietl : MonoBehaviour
{
    public Material podswietlony;
    public Material normalny;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<Renderer>().material = podswietlony;
        }
    }
    void Update()
    {
        
    }
}
