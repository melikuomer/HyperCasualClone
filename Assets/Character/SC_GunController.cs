using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_GunController : MonoBehaviour
{
    float time = 0f;
    [SerializeField]
    private GameObject _bullet;    

    //this one doesn't persist between levels
    CharacterStateDTO characterState = new CharacterStateDTO() {fireRate = 1f};

    //this one does persist
    CharacterStateDTO persistentState=new();

    BulletController bc; 

    public void Awake(){
        SaveUtils.LoadState(ref persistentState);

        //if error code is read that means the save was not existent so we create a new state
       
        if(persistentState.fireRate == 0){
            Debug.Log("save not found or corrupted");
            persistentState = new(){
                fireRate = 100,
                year = 2000,

            };
        }

    }

    public void OnDestroy() {
        //Saving state on controller destroyed // saves state between levels
        Debug.Log("Destroyed");
        persistentState.money = characterState.money;
        SaveUtils.SaveState(persistentState);

    }

    
    public void  OnApplicationQuit() {
        Debug.Log("Destroyed 3");

        SaveUtils.SaveState(persistentState);
        
    }
    
    // Start is called before the first frame update
    public void Start()
    {   
        characterState = persistentState;
        bc = _bullet.GetComponent<BulletController>();
        // read base values from some storage
    }
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            characterState += interactable.Interact();
            Destroy(other.gameObject);
            Debug.Log(characterState.year);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        time +=Time.deltaTime;
        if(time> 50/characterState.fireRate){
            bc.InitValues(characterState.range, characterState.fireRate);
            Instantiate(_bullet, transform.position, Quaternion.identity);
            time = 0;
            //spawn bullet for x times; x is bullet count  
            //ates et
        }



    }

    
}
