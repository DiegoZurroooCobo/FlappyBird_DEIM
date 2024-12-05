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
        //if(Input.GetMouseButtonDown(0)) 
        //{
        //    Vector3 screenCoords = Input.mousePosition;
        //    screenCoords.z = 10;
        //    Vector3 gameCoords = _camera.ScreenToWorldPoint(screenCoords);
        //    Instantiate(particlePrefab, gameCoords, Quaternion.identity);
        //}

        foreach(Touch touch in Input.touches) 
        { 
            if(touch.phase == TouchPhase.Began) 
            {
                Vector3 screenCoord = touch.position;
                screenCoord.z = 10;
                Vector3 gameCoords = _camera.ScreenToWorldPoint(screenCoord);
                Instantiate(particlePrefab, gameCoords, Quaternion.identity);
            }
        }
    }
}
