using System.Collections;// condiciciones de preprocesador 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int jumpForce;
    public Material mat;

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
            StartCoroutine(WaitDeath());
        }

        if (GameManager.instance.GetHits() >= Random.Range(3, 6))
        {
            AdDisplayManager.instance.ShowAd();
            GameManager.instance.SetHits(0);
        }
    }

    IEnumerator WaitDeath()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GameManager.instance.SetHits(GameManager.instance.GetHits() + 1);
        GameManager.instance.SetScore(0);
        AudioManager.instance.ClearAudios();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        yield return new WaitForSeconds(1f);
    }
}
