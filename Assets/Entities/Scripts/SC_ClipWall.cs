using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SC_ClipWall : MonoBehaviour, IInteractable
{

    GameObject player;

    [SerializeField]
    int[] ints = new int [3]; 

    int bulletCount; 
    
    int index = 0;
    public CharacterStateDTO Interact()
    {
        // check where was the player when interact function is called;
        return new CharacterStateDTO(){year = ints[index]};     

   
    }

    public void RecieveBullets(int bullets){
        bulletCount += bullets;
        if (ints[index] < bulletCount && index<2) index++;

    }

    public void Awake() {
       GameObject[] objects = gameObject.GetComponentsInChildren<GameObject>().Where(x => x.name.Contains("most")).ToArray();
       Vector3.Distance(objects[0].transform.position, objects[1].transform.position);

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
