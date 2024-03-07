using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_Chest : MonoBehaviour , IHittable

{

    [SerializeField]
    GameObject moneyObject; 

    [SerializeField]
    int requiredHits =20;
    [SerializeField]
    TextMeshPro tmp; 
    public void RecieveHit()
    {
        requiredHits--;
        tmp.text=requiredHits.ToString();
        if(requiredHits<=0){
            Instantiate (moneyObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tmp.text= requiredHits.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
