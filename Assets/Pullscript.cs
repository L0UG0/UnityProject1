using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BallController : MonoBehaviour
{
    public string inputButtonName = "Pull";
    public float distance = 50f;
    public float speed = 1f;
    public GameObject ball;
    public float power = 2000f;

    private bool ready = false;
    private bool fire = false;
    private bool returning = false;
    private float moveCount = 0f;

    private Vector3 initialPosition; // Zmienna na pozycję początkową
    private Rigidbody rb; // Referencja do komponentu Rigidbody

    void Start()
    {
        // Zapisz pozycję początkową obiektu
        initialPosition = transform.position;

        // Pobierz komponent Rigidbody
        rb = GetComponent<Rigidbody>();
        
        // Upewnij się, że Rigidbody istnieje i jest używane
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Ustaw na kinematyczny, aby kontrolować ruch ręcznie
        }
    }

    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "Ball")
        {
            ready = true;
        }
    }

    void Update()
    {
        if (Input.GetButton(inputButtonName) && !returning)
        {
            // Przesuwaj obiekt do przodu, gdy przycisk jest trzymany
            if (moveCount < distance)
            {
                transform.Translate(0, 0, speed * Time.deltaTime); // Zmienione na dodatnie speed
                moveCount += speed * Time.deltaTime;
                fire = true;
            }
        }
        else if (moveCount > 0) // Warunek rozpoczęcia powrotu
        {
            returning = true; // Włącz tryb powrotu
            fire = false; // Przestań próbować strzelać
        }

        if (returning)
        {
            // Strzel kulą, jeśli gotowe
            if (fire && ready)
            {
                ball.transform.TransformDirection(Vector3.forward * 10);
                ball.GetComponent<Rigidbody>().AddForce(0, 0, moveCount * power);
                
                fire = false;
                ready = false;
            }

            // Powrót do pozycji początkowej z użyciem Rigidbody.MovePosition
            Vector3 newPosition = Vector3.MoveTowards(transform.position, initialPosition, 20 * Time.deltaTime);
            rb.MovePosition(newPosition); // Przesunięcie przez Rigidbody dla zachowania kolizji
            moveCount -= 20 * Time.deltaTime;

            // Sprawdź, czy dotarł do pozycji początkowej
            if (transform.position == initialPosition)
            {
                moveCount = 0;
                returning = false;
            }
        }
    }
}
