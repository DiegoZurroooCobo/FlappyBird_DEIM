using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObjectPool bulletPool;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        { 
            GameObject obj = bulletPool.GimmeInactiveGameObject();
            if(obj) 
            {
                obj.SetActive(true); //quitarlo del estuche 
                obj.transform.position = transform.position;
                obj.GetComponent<Bullet>().SetDirection(transform.forward); 
            }
        }
    }
}
