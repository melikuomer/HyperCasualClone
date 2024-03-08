using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SC_Clip : MonoBehaviour, IHittable
{ 

    [SerializeField]
    MovementDTO movementStats; 

    [SerializeField]
    GameObject bullet;
    
    GameObject conveyor;

    int bulletCount=0; 
    [SerializeField]
    int maxBullets = 15; 
    int layerCount=2;

    bool isFull = false;

    public void Start () {
        
        conveyor = FindObjectsOfType<GameObject>().Where(x => x.tag == "Conveyor").First();
    }


    public int GetBullets(){return bulletCount;}
    public void RecieveHit()
    {
        if (!isFull){
            AddBullet();
            bulletCount++;
        }      
        if (bulletCount == maxBullets){
        isFull =true;
        StartCoroutine(MoveToTarget());
            // do movement logic here     
        }
        
    }

    int currentLayer = 0;
    int bulletsOnCurrentLayer = 0;
    void AddBullet(){
        int layerCapacity = 5*(currentLayer+1);
        float temp = 2*bulletsOnCurrentLayer*(float)Math.PI/layerCapacity;
        Vector3 bulletPos = new Vector3((float)Math.Cos(temp)*(currentLayer+1)*.2f,(float) Math.Sin(temp)*(currentLayer+1)*.2f,0);
        Instantiate(bullet, bulletPos+transform.position + 1f *Vector3.back,Quaternion.identity , transform);
         bulletsOnCurrentLayer++;
         
         if (layerCapacity == bulletsOnCurrentLayer){
            currentLayer++;
            bulletsOnCurrentLayer=0;
         }  
    }

    //deprecated
    void DrawBullets(){
        
         for(int i = 0 ;i<layerCount ; i++){
            int layerCapacity = 5*(i+1);
            for(int j = 0; j<layerCapacity; j++){
                
                float temp = 2*j*(float)Math.PI/layerCapacity;
                Vector3 bulletPos = new Vector3((float)Math.Cos(temp)*(i+1)*.2f,(float) Math.Sin(temp)*(i+1)*.2f,0);
                Instantiate(bullet, bulletPos+transform.position + .5f *Vector3.back,Quaternion.identity , transform);
            }
        }
    }


    IEnumerator MoveToTarget(){
    
        Vector3 startPosition = transform.position; // Starting position of the object

        // Calculate the total distance to travel
        float totalDistance = Math.Abs(transform.position.x - conveyor.transform.position.x);
        float movementRange = totalDistance;
        Vector3 targetPosition = startPosition + Vector3.left * movementRange; 

        // Calculate the movement per frame based on movement range and total distance
        float movementPerFrame = .3f / totalDistance;

        // Calculate the new position for each frame
        float traveledDistance = 0f;
        while (traveledDistance < movementRange)
        {
            traveledDistance += movementPerFrame;

            // Clamp traveledDistance to avoid exceeding the range
            traveledDistance = Mathf.Clamp(traveledDistance, 0f, movementRange);

            // Use Lerp to calculate the new position based on traveled distance
            transform.position = Vector3.Lerp(startPosition, targetPosition, traveledDistance / movementRange);

            // Yield control back to Unity until the next frame
            yield return null;
        }

        // Optionally, snap to the target position after the lerp is complete
        transform.position = targetPosition;
        
    
    }

    // Start is called before the first frame update
    

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
