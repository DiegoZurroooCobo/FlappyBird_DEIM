using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float maxTime;

    private float currentTime;
    private Vector3 dir;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= maxTime) 
        {
            currentTime = 0;
            gameObject.SetActive(false); // se "devuelve a la pool"  
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = speed * dir;
    }

    public void SetDirection(Vector3 value) 
    { 
        dir = value;
    } 
}
