using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Spike : MonoBehaviour , IInteractable , ICollidable
{

    [SerializeField]
    CharacterStateDTO stateDTO;
    bool didCollide = false;
    public int Collide()
    {
        if(!didCollide) {
            didCollide = true;
            return -1;
        }
        return 1;
    }

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
