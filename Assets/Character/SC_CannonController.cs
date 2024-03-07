using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CannonController : MonoBehaviour
{
    float time = 0f;
    [SerializeField]
    private GameObject _bullet;    

    [SerializeField]
    SO_Gun cannon;
    BulletController bc; 
    float range;
    float fireRate;

    

    // Start is called before the first frame update
    public void Start()
    {   
         range = cannon.gunStats.Range;
         fireRate = cannon.gunStats.FireRate ;
        
        bc = _bullet.GetComponent<BulletController>();
        Instantiate(cannon.gameObject, transform);
        // read base values from some storage
    }
    

    // Update is called once per frame
    public void Update()
    {
        time +=Time.deltaTime;
        if(time> 50/fireRate){
            bc.InitValues(range, fireRate);
            Instantiate(_bullet, transform.position, Quaternion.identity);
            time = 0;
            
        }
    }


}
