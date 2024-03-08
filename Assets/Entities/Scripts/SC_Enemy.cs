using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Enemy : MonoBehaviour , IHittable , ICollidable
{


    [SerializeField]
    MovementDTO movementStats;

    public int Collide()
    {
        throw new System.NotImplementedException();
    }

    public void RecieveHit()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    

    void Move(){
        if(movementStats.canMove){
            if(movementStats.isMoving){
                transform.Translate(movementStats.movementSpeed * Time.deltaTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
