using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    private TMP_Text text;
    public GameManager.GameManagerVariables variable;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        switch (variable)
        {
            case GameManager.GameManagerVariables.TIME:
                text.text = "Time: " + GameManager.instance.GetTime().ToString("#.##");
                break;
            case GameManager.GameManagerVariables.SCORE:
                text.text = "Points: " + GameManager.instance.GetScore();
                break;
            default:
                break;
        }
    }
}
