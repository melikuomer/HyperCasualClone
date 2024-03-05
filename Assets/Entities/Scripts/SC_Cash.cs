using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Cash : MonoBehaviour , IInteractable
{

    [SerializeField]
    CharacterStateDTO stateDTO;
    public CharacterStateDTO Interact()
    {
        return stateDTO;
    }


}
