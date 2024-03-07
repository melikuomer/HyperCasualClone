
using UnityEngine;


public class SC_GunController : MonoBehaviour
{
    float time = 0f;
    [SerializeField]
    private GameObject _bullet;    

    SO_Gun gun;
    BulletController bc; 
    float range;
    float fireRate;

    GameObject gunObject; 
    
    public void OnFireRateChange(float newValue){
        fireRate +=newValue;
    }
    // Start is called before the first frame update
    public void Start()
    {   
         range = SC_CharacterState.characterState.Range;
         fireRate = SC_CharacterState.characterState.FireRate ;
        SC_CharacterState.onFireRateChanged += OnFireRateChange;
        bc = _bullet.GetComponent<BulletController>();
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

    public void SetGun(SO_Gun newGun){
        if(gunObject) Destroy(gunObject);
        
        gunObject = Instantiate(newGun.gameObject, transform);
        range += newGun.gunStats.Range;
        fireRate += newGun.gunStats.FireRate;
        if(gun){
        range -=  gun.gunStats.Range;
        fireRate -= gun.gunStats.FireRate;
        }
        gun = newGun;

        
    }

    
}
