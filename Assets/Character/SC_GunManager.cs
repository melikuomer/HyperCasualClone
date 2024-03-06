using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class SC_GunManager : MonoBehaviour
{
    [SerializeField]
    SO_Gun[] guns ;
    int currentGunIndex= 0;
    int gunIndex=0;

    List<SC_GunController> controllers;

    int year; 
    

    void Awake(){
        controllers = GetComponentsInChildren<SC_GunController>().ToList();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        SC_CharacterState.onYearChanged += OnYearChanged;
        OnYearChanged(SC_CharacterState.characterState.Year);
        var index = PickGun();
        currentGunIndex = index;
        
        controllers.ForEach(controller =>{
            controller.SetGun(guns[index]);
        });
    }

    void OnYearChanged (float newYear){
        year += (int)newYear;
        gunIndex=(year % 100 )/10;
        ChangeGun();
        Debug.Log("Gun index is " + gunIndex + "Current gun index is " + currentGunIndex + "new year " + newYear);
    }


    void ChangeGun(){
        int index = PickGun();
        if (gunIndex>currentGunIndex && gunIndex<10){
            //OnYearChanged(SC_CharacterState.characterState.Year);
            currentGunIndex = gunIndex;
            controllers.ForEach(controller =>{
            controller.SetGun(guns[gunIndex]);
        });
        }
    }
    int PickGun(){
        if(currentGunIndex < gunIndex){
            
            return gunIndex;
        }
        return currentGunIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
