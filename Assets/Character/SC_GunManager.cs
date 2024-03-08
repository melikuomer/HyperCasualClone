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
    [SerializeField]
    GameObject gunObject;
    [SerializeField]
    GameObject cannonObject; 

    List<SC_CannonController> cannonControllers;
    List<SC_GunController> controllers;
    int gunCount = 1;
    int year; 


    int cannonCount = 0;
    

    void Awake(){
        controllers = new();
        cannonControllers = new();
        //controllers = GetComponentsInChildren<SC_GunController>().ToList();
        //create gun object for each gun count

        for (int i =0; i<gunCount ; i++){
            controllers.Add(Instantiate(gunObject, transform.position+(gunCount-1)*Vector3.left*.5f, Quaternion.identity, transform).GetComponent<SC_GunController>());
        }
    }
    void OnDestroy(){
        SC_CharacterState.onYearChanged -= OnYearChanged;
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
        if ( gunIndex<10){
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


    public void AddGun(){
        gunCount++;
        controllers.Add(Instantiate(gunObject, transform.position+(gunCount-1)*Vector3.left*.5f, Quaternion.identity, transform).GetComponent<SC_GunController>());
        ChangeGun();
    }

    public void AddCannon(){
        cannonCount ++;
        cannonControllers.Add(Instantiate(cannonObject, transform.position+(cannonCount)*Vector3.right*.5f, Quaternion.identity, transform).GetComponent<SC_CannonController>());
    }

}
