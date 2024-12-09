using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public GameObjectPool pipePool;
    public float maxTime;

    private float currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= maxTime) 
        {
            GameObject obj = pipePool.GimmeInactiveGameObject();
            if(obj) 
            { 
                obj.SetActive(true);
                obj.transform.position = transform.position;
                obj.GetComponent<Pipe>().SetDirection(transform.right);
            }
        }
    }
}
