using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SC_ProgressBar : MonoBehaviour
{


    int lastMajorYear; 
    int nextMajorYear;

    int currentYear;

    
    Slider pb;

    [SerializeField]
    TextMeshProUGUI lastYearTMP; 
    [SerializeField]
    TextMeshProUGUI nextYearTMP; 

    
    void Awake(){
        SC_CharacterState.onYearChanged += ValueChanged;
        pb = GetComponentInChildren<Slider>();
        

    }


    void ValueChanged(float newValue){
        currentYear += (int)newValue;
        if(currentYear>=nextMajorYear){
            lastMajorYear= nextMajorYear;
            nextMajorYear += 10;
            lastYearTMP.text= lastMajorYear.ToString();
            nextYearTMP.text= nextMajorYear.ToString();
        }
        pb.value = (currentYear-lastMajorYear)/10f;
        Debug.Log("Happy New Year " + newValue);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentYear = (int)SC_CharacterState.characterState.Year; 
        lastMajorYear = (currentYear/10)*10;
        nextMajorYear = lastMajorYear+10;
        lastYearTMP.text= lastMajorYear.ToString();
        nextYearTMP.text= nextMajorYear.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
