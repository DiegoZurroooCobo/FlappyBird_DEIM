using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateParticle : MonoBehaviour
{
    public GameObject particlePrefab;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Instruccion de procesador que se ejecuta antes de compilar el juego
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            InstanceParticles(Input.mousePosition, Color.blue);
        }

#elif UNITY_ANDROID
        foreach(Touch touch in Input.touches) 
        { 
            if(touch.phase == TouchPhase.Began) 
            {
                InstanceParticles(touch.position, Color.magenta);
            }
        }
#endif
    }
        void InstanceParticles(Vector3 screenCoords, Color color)
        {
            screenCoords.z = 10;
            Vector3 gameCoords = _camera.ScreenToWorldPoint(screenCoords);
            GameObject particle = Instantiate(particlePrefab, gameCoords, Quaternion.identity);
        particle.GetComponent<Renderer>().material.color = color;
        }
}

