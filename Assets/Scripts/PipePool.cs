using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public GameObjectPool pipePool;
    public float maxTime;
    public float minHeight, maxHeight;

    private float currentTime;


    private void Start()
    {
        PipeSpawn();
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= maxTime) 
        {
            PipeSpawn();
            currentTime = 0;
        }

    }

    void PipeSpawn()
    {
        GameObject obj = pipePool.GimmeInactiveGameObject();
        if (obj)
        {
            obj.SetActive(true);
            obj.transform.position = transform.position;
            obj.GetComponent<Pipe>().SetDirection(Vector3.left);
            obj.transform.position = new Vector3(0, Random.Range(minHeight, maxHeight), 0);
        }

    }
}
