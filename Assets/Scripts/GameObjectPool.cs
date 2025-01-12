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
    void Awake()
    {
        _pool = new List<GameObject>(); // se crea un lista 
        for(int i = 0; i < sizePool; i++) // se recorre la lista 
        {
            AddGameObject(); // se añaden 
        }
    }

    public GameObject GimmeInactiveGameObject() 
    { 
        foreach(GameObject obj in _pool) // por cada objeto en la lista de la pool 
        {
            if (!obj.activeSelf) // si el objeto no esta activo 
            { 
                return obj; // se devuelve 
            }
        }

        if(shouldExpand) // si se tiene que exapndir la lista 
        { 
            return AddGameObject(); // se devuelve el metodo de añadir mas obejtos 
        }
        return null;
    }

    GameObject AddGameObject() // metodo de añadir los objetos 
    { 
        GameObject clone = Instantiate(objectToPool); // se crea un gameObject y se instancia el objeto que va a salir 
        clone.SetActive(false); // se desactiva para que no se utiliza de primeras
        _pool.Add(clone); // se añade el clon del gameObject a la pool
        return clone; // se devuelve el clon
    }
}
