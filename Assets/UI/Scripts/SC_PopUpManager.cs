using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PopUpManager : MonoBehaviour
{

    [SerializeField] 
    GameObject textPrefab;

    SC_PopUpText sc_put;
    public void OnYearChanged (float year){
        Debug.LogWarning("sa");
        sc_put.text = year;
        
        if(year < 0 ){

        }
        Instantiate(textPrefab, transform);
    }

    public void OnDestroy(){
        SC_CharacterState.onYearChanged -= OnYearChanged;
    }


    void Awake (){
     sc_put =  textPrefab.GetComponent<SC_PopUpText>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SC_CharacterState.onYearChanged += OnYearChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
