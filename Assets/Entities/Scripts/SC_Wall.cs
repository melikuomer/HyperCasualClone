using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SC_Wall : MonoBehaviour , IHittable , IInteractable , ICollidable
{
    [SerializeField]
    float baseValue = 20f; 
    [SerializeField]
    TextMeshPro tmp; 
    float changePerHit = 2f;
    [SerializeField]
    CharacterStateDTO stateDTO = new CharacterStateDTO () ;
    [SerializeField]
    TextMeshPro typeTxt; 




    [SerializeField]
    GameObject shieldObject;
    [SerializeField]
    TextMeshPro tmpShield;
    [SerializeField]
    int shield = 0;
    bool didCollide = false;
    public int Collide()
    {
        if(shield >0 && !didCollide){
            didCollide = true;
            return -1;
        }
        return 1;
    }

    public CharacterStateDTO Interact()
    {
        return new CharacterStateDTO () {FireRate= baseValue};
    }

    public void RecieveHit(){
        if(shield > 0){
            shield--;
            tmpShield.text = shield.ToString();

        }
        if(shield <= 0) {
            shieldObject.SetActive(false);
        }
        baseValue += changePerHit;
        tmp.text = baseValue.ToString();
    }

    private void OnDestroy() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        stateDTO.FireRate= baseValue;
        tmp.text = baseValue.ToString();
        string type = Utils.ReflectionHelper.GetNonZeroMemberName(stateDTO);
        changePerHit = Utils.ReflectionHelper.GetValueWithName(stateDTO,type);
        typeTxt.text = ObjectNames.NicifyVariableName(type);



        if(shield>0){
            shieldObject.SetActive(true);
            tmpShield.text = shield.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
