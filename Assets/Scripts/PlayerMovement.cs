using System.Collections;// condiciciones de preprocesador 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int jumpForce;
    public AudioClip deathClip;

    private Rigidbody _rb;
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
        if (Input.GetKeyDown(KeyCode.Space)) // al pulsar el espacio 
        {
            Movementjump(); // se llama al metodo de movimiento 
        }

#elif UNITY_ANDROID
        foreach (Touch touch in Input.touches) // por cada toque
        {
            if (touch.phase == TouchPhase.Began)
            {
                Movementjump(); // se llama el metodo de moviemiento 
            }
        }
#endif
         if (GameManager.instance.GetHits() >= Random.Range(3, 6)) // si los golpes contra las tuberias son mayores o iguales a un random entre 3 y 5 
        {
            AdDisplayManager.instance.ShowAd(); // se muestra un anuncio 
            GameManager.instance.SetHits(0);    // se setea los golpes a 0 
        }
    }
    void Movementjump()
    {
        _rb.AddForce(Vector3.up * jumpForce); // se añade una fuerza hacia arriba 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Pipe>()) // al colisionar contra las tuberias 
        {
            StartCoroutine(WaitDeath()); // comienza la corrutina 
        }
    }

    IEnumerator WaitDeath() // corrutina para muerte 
    {
        GetComponent<PlayerMovement>().enabled = false; // se desactiva el codigo de player Movement 
        GetComponent<CapsuleCollider>().enabled = false; // se desactiva el colider del player
        AudioSource src = AudioManager.instance.PlayAudio(deathClip, "deathClip", false); // se instancia el audio de muerte 
        GameManager.instance.SetHits(GameManager.instance.GetHits() + 1); // aumenta en 1 el numero de golpes contra las tuberias
        while( src && src.isPlaying) // mientras que el audio de muerte este sonando 
        { 
            yield return null;  // espera a que termine el audio
        }
        AudioManager.instance.ClearAudios(); // se quitan todos los audios
        GameManager.instance.SetScore(0);  // la puntuacion se setea a 0 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // se carga de nuevo la escena 
    }
}
