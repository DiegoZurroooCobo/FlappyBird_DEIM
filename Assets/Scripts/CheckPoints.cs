using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public AudioClip pointsClip;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>()) 
        {
            GameManager.instance.SetScore(GameManager.instance.GetScore() + 1);
            AudioManager.instance.PlayAudio(pointsClip, "pointsClip", false);
        }
    }
}
