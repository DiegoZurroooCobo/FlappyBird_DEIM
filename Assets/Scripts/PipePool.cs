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
        PipeSpawn(); // se llama al objeto en el incio 
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= maxTime) // si el tiempo actual supera el tiempo maximo 
        {
            PipeSpawn(); // se llama al metodo y spawnea otra tuberia 
            currentTime = 0; // el timepo actual vuelve a 0
        }

    }

    void PipeSpawn() // metodo para spawnear las tuberias 
    {
        GameObject obj = pipePool.GimmeInactiveGameObject();
        if (obj)
        {
            obj.SetActive(true); // se activa el objeto 
            obj.transform.position = transform.position; 
            obj.transform.position = new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z); // se le da una posicion al obejto 
            obj.GetComponent<Pipe>().SetDirection(Vector3.left); // se le da una direccion 
        }

    }
}
