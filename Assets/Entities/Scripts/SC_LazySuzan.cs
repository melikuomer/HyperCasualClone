using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_LazySuzan : MonoBehaviour, IInteractable
{
    public float rotationSpeed = 50f; // Degrees per second

    [SerializeField]
    SO_Gun gun;

    public CharacterStateDTO Interact()
    {
        Destroy(GameObject.FindWithTag("Player").gameObject);
        return new CharacterStateDTO();
    }

    void Start(){
        
        var go_instance = Instantiate(gun.gameObject, transform.position+ Vector3.up*2f, Quaternion.identity,transform);
        go_instance.transform.localScale=new Vector3(1,1,1) *4;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }

}
