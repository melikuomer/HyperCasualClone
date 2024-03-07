using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SC_CharacterState : MonoBehaviour
{

    Dictionary<string, Action<float>> events = new(); 
    


    //
    public delegate void OnFloatChanged(float value);
    public static event OnFloatChanged onFireRateChanged;

    public static event OnFloatChanged onRangeChanged;

    public static event OnFloatChanged onYearChanged;


    public static event OnFloatChanged onPowerChanged;


    public static event OnFloatChanged onHealthChanged;


    public static event OnFloatChanged onMoneyChanged;
    
    public void onFloatChanged (float value){
        Debug.Log("event recieved "+value);
    }

    
    //this one doesn't persist between levels
    public static CharacterStateDTO characterState = new CharacterStateDTO() {FireRate = 1f};

    //this one does persist
    public static CharacterStateDTO persistentState=new();



    [SerializeField]
    float pushBackForce= 1f;

    void InitEvents(){
        List<string> strings =  Utils.ReflectionHelper.GetFieldNames(characterState);
        //TODO fix this with appropriate reflection implementation

        strings.ForEach(name =>{
            switch(name){
                case "FireRate":
                    events.Add(name , (float value)=> onFireRateChanged(value));
                    break;
                case "Range":
                    events.Add(name , (float value)=> onRangeChanged(value));
                    break;
                case "Year":
                    events.Add(name , (float value)=> onYearChanged(value));
                    break;
                case "Power":
                    events.Add(name , (float value)=> onPowerChanged(value));
                    break;
                case "Health":
                    events.Add(name , (float value)=> onHealthChanged(value));
                    break;
                case "Money":
                    events.Add(name , (float value)=> onMoneyChanged(value));
                    break;


                default:
                    Debug.LogError("Switch Case has missing field names");
                    break;
        
            }
        });

    }

    
    void OnValueChanged (CharacterStateDTO newState){
        string typeName = Utils.ReflectionHelper.GetNonZeroMemberName(newState);
        Debug.Log("new state "+ typeName);
        if (events.TryGetValue(typeName, out Action<float> action))
        {
            action.Invoke(Utils.ReflectionHelper.GetValueWithName(newState, typeName));
        }


    }

    
    

    public void Awake(){
        SaveUtils.LoadState(ref persistentState);
        InitEvents();

        //if error code is read that means the save was not existent so we create a new state
       
        if(persistentState.FireRate == 0){
            Debug.Log("save not found or corrupted");
            persistentState = new(){
                FireRate = 100,
                Year = 2000,

            };
        }
        characterState = persistentState;

    }

    public void OnDestroy() {
        //Saving state on controller destroyed // saves state between levels
        //Debug.Log("Destroyed");
        persistentState.Money = characterState.Money;
        SaveUtils.SaveState(persistentState);

    }

    
    public void  OnApplicationQuit() {
        //Debug.Log("Destroyed 3");

        SaveUtils.SaveState(persistentState);
        
    }

    public void OnTriggerEnter(Collider other) {

    //create  a new ICanPush interface check first if he has it wait its return value 
    //if it's non zero push yourself back if its zero check IInteractable 
    //if it's negative kill the player

    if (other.gameObject.TryGetComponent(out ICollidable collidable)){
        int value =  collidable.Collide();

        if (value < 0){
            //geri it
            transform.Translate(Vector3.back *pushBackForce);
            return;
        }
        else if (value ==0){
            //oldur
            Debug.Log("YOU DIED");
            return;
        }else {
            //birsey yapma

        }
    }
    if (other.gameObject.TryGetComponent(out IInteractable interactable))
    {
        
        CharacterStateDTO tempState = interactable.Interact();
        OnValueChanged(tempState);
        //characterState += interactable.Interact();
        Destroy(other.gameObject);
        Debug.Log(characterState.Year);
    }
}

    
    

    // Start is called before the first frame update
    void Start()
    {
        onFireRateChanged += onFloatChanged;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
