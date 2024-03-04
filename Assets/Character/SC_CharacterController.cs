using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CharacterController : MonoBehaviour
{

    [SerializeField]
    private float _limit = 3f; 

    float startPosition = 0;

    float mousePositionScalar = .02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetMouseButtonDown(0)){
            startPosition = Input.mousePosition.x *mousePositionScalar;
        }

        else if(Input.GetMouseButton(0)){

            float x =  Input.mousePosition.x *mousePositionScalar - startPosition;    
            x=  Math.Clamp(x+transform.position.x,-_limit, _limit );
        Debug.Log(x);
        
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            startPosition =  Input.mousePosition.x *mousePositionScalar;
        }else {
            startPosition = 0;
        }


    }
}
