using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_GunController : MonoBehaviour
{

    float fireRate = 10f;


    float time = 0f;
    [SerializeField]
    private GameObject _bullet;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;
        if(time> 1/fireRate){

            Instantiate(_bullet, transform.position, Quaternion.identity);
            time = 0;
            //spawn bullet for x times; x is bullet count  
            //ates et
        }



    }

    
}
