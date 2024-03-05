using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SC_Wall : MonoBehaviour , IHittable , IInteractable
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

    public CharacterStateDTO Interact()
    {
        return new CharacterStateDTO () {fireRate= baseValue};
    }

    public void RecieveHit(){
        baseValue += changePerHit;
        tmp.text = baseValue.ToString();
    }

    private void OnDestroy() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        stateDTO.fireRate= baseValue;
        string type = Utils.ReflectionHelper.GetNonZeroMemberName(stateDTO);
        typeTxt.text = ObjectNames.NicifyVariableName(type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
