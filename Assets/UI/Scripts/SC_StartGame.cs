using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_StartGame : MonoBehaviour
{
    [SerializeField]
    GameObject ui;
    void Start(){
        Time.timeScale = 0;
    }

    public void StartGame(){
        Time.timeScale = 1;
        ui = GameObject.FindWithTag("StartGameMenu");
        ui.SetActive(false);
        gameObject.SetActive(false);
    }
}
