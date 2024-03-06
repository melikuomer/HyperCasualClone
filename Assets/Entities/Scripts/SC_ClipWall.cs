using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class SC_ClipWall : MonoBehaviour, IInteractable
{

    GameObject player;

    [SerializeField]
    int[] ints = new int [3]; 

    int bulletCount; 
    
    [SerializeField]
    float scalar = .2f;
    Vector3 startPos;
    float distance;
    float offset;
    int index = 0;

    [SerializeField]
    GameObject bulletMesh;
    public CharacterStateDTO Interact()
    {
        // check where was the player when interact function is called;
        float playerDist = Math.Abs(player.transform.position.x - startPos.x);
        float percentage = playerDist/distance;
        Debug.Log(((int)(percentage*10)));
        int tier = ((int)(percentage*10))/3;
       
        if(tier>=0&& tier<3){
            Debug.Log("HIT");
        return new CharacterStateDTO(){Year = ints[tier]};   }  
        else return new CharacterStateDTO();

   
    }

    public void RecieveBullets(int bullets){
         if(bulletCount== ints[2]) return;
        for(int i= 1; i<= bullets;i++){

            Instantiate(bulletMesh, startPos + Vector3.right*offset*(bulletCount + i) * scalar, Quaternion.identity, transform);
            bulletCount++;
            if(bulletCount== ints[2]) break;
        }
        
        if (ints[index] < bulletCount && index<2) index++;

    }

    public void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Clip")){
            var bullets = other.GetComponent<SC_Clip>().GetBullets();
            RecieveBullets(bullets);
            Destroy(other.gameObject);
        }
    }

    public void Awake() {
        Transform[] objects = gameObject.GetComponentsInChildren<Transform>().Where(x => x.gameObject.name.Contains("Most")).ToArray();
        startPos= objects[0].transform.position;
        distance = Vector3.Distance(objects[0].transform.position, objects[1].transform.position);
        
        offset = distance/20f;
         // get playing character
       player=  GameObject.FindWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
