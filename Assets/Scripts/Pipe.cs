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
        if(currentTime >= maxTime) 
        { 
            currentTime = 0;
            gameObject.SetActive(false);
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
