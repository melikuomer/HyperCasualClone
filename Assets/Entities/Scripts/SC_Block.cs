using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_Block : MonoBehaviour , IHittable , ICollidable
{

    [SerializeField] 
    float health = 5; 
    [SerializeField]
    TextMeshPro healthText;

   
    public void RecieveHit()
    {
        UpdateHealth(1);
    }

    private void UpdateHealth(float value){
        health -= value;
        healthText.text = health.ToString();
        if (health == 0){
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Collide()
    {
        return 0;
    }
}
