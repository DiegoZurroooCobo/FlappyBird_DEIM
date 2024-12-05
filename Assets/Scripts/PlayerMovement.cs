using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int jumpForce;
    private Camera _cam;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Movementjump();
        }


#elif UNITY_EDITOR
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Movementjump();
            }
        }
    }

#endif
        void Movementjump()
        {
            _rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
