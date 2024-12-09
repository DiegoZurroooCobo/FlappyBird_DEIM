using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [Tooltip("Object to pool")]
    public GameObject objectToPool;
    [Tooltip("Initial pool size")]
    public uint sizePool;
    [Tooltip("if bool true, size increases")]
    public bool shouldExpand = false;
    
    private List<GameObject> _pool;
    // Start is called before the first frame update
    void Start()
    {
        _pool = new List<GameObject>();
        for(int i = 0; i < sizePool; i++) 
        {
            AddGameObject();
        }
    }

    public GameObject GimmeInactiveGameObject() 
    { 
        foreach(GameObject obj in _pool) 
        {
            if (!obj.activeSelf) // si el objeto no esta activo 
            { 
                return obj; // se devuelve 
            }
        }

        if(shouldExpand) 
        { 
            return AddGameObject();
        }
        return null;
    }

    GameObject AddGameObject() 
    { 
        GameObject clone = Instantiate(objectToPool);
        clone.SetActive(false); // se desactiva para que no se utiliza de primeras
        _pool.Add(clone);
        return clone;
    }
         
    // Update is called once per frame
    void Update()
    {
        
    }
}
