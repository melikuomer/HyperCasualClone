using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_GunController : MonoBehaviour
{

   


    float time = 0f;
    [SerializeField]
    private GameObject _bullet;    
    CharacterStateDTO characterState = new CharacterStateDTO() {fireRate = 1f};

    BulletController bc; 
    // Start is called before the first frame update
    void Start()
    {   
        bc = _bullet.GetComponent<BulletController>();
        // read base values from some storage
    }
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            characterState += interactable.Interact();
            Destroy(other.gameObject);
            Debug.Log(characterState.money);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;
        if(time> 1/characterState.fireRate){
            bc.InitValues(characterState.range, characterState.fireRate);
            Instantiate(_bullet, transform.position, Quaternion.identity);
            time = 0;
            //spawn bullet for x times; x is bullet count  
            //ates et
        }



    }

    
}
