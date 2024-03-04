using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SC_Clip : MonoBehaviour, IHittable
{ 
    [SerializeField]
    GameObject bullet;

    int bulletCount=0; 
    int maxBullets = 15; 
    int layerCount=2;
    public void RecieveHit()
    {

        bulletCount++;
       AddBullet();
        
    }

    int currentLayer = 0;
    int bulletsOnCurrentLayer = 0;
    void AddBullet(){
        int layerCapacity = 5*(currentLayer+1);
        float temp = 2*bulletsOnCurrentLayer*(float)Math.PI/layerCapacity;
        Vector3 bulletPos = new Vector3((float)Math.Cos(temp)*(currentLayer+1)*.2f,(float) Math.Sin(temp)*(currentLayer+1)*.2f,0);
        Instantiate(bullet, bulletPos+transform.position + .5f *Vector3.back,Quaternion.identity , transform);
         bulletsOnCurrentLayer++;
         if (bulletCount == maxBullets){
            
         }
         if (layerCapacity == bulletsOnCurrentLayer){
            currentLayer++;
            bulletsOnCurrentLayer=0;
         }  
    }
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
    // Start is called before the first frame update
    void Start()
    {
        //layerCount = maxBullets/5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
