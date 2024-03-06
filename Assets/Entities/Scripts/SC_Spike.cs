using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Spike : MonoBehaviour , IInteractable
{

    [SerializeField]
    CharacterStateDTO stateDTO; 
    public CharacterStateDTO Interact()
    {   
        
        return stateDTO;
    }

    // Start is called before the first frame update
    void Start()
    {
        stateDTO.Year= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
