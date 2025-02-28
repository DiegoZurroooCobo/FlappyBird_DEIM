using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float maxTime, speed;

    private float currentTime;
    private Rigidbody rb;
    private Vector3 dir = Vector3.left;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= maxTime) // si el tiempo actual supera el tiempo maximo 
        { 
            currentTime = 0; // el tiempo se vuelve 0 
            gameObject.SetActive(false); // se desactiva el objeto de la pool 
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = speed * dir;
    }

    public void SetDirection(Vector3 value) // metodo para darle una direccion a las tuberias 
    { 
        dir = value;
    }
}
