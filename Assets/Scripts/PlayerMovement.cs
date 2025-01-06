using System.Collections;// condiciciones de preprocesador 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int jumpForce;
    public AudioClip jumpClip;

    private Rigidbody _rb;
    private int hits;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE  // intrucciones condicionales 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Movementjump();
            //_animator.SetBool("Flying", true);
        }
        else 
        {
            //_animator.SetBool("Flying", false);
        }


#elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Movementjump();
            }
        }
#endif
    }
    void Movementjump()
    {
        _rb.AddForce(Vector3.up * jumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Pipe>())
        {
            GameManager.instance.SetHits(GameManager.instance.GetHits() + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.instance.SetScore(0);
        }

        if (GameManager.instance.GetHits() >= Random.Range(3, 6))
        {
            AdDisplayManager.instance.ShowAd();
            GameManager.instance.SetHits(0);
        }
    }
}
