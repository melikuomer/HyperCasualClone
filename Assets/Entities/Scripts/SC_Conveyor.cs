using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Conveyor : MonoBehaviour
{
    // Start is called before the first frame update

    Material mat; 
    void Start()
    {
       // mat = transform.GetComponentInChildren<MeshRenderer>().GetMaterials;
    }
    List<Transform> transforms = new();
    // Update is called once per frame
    void Update()
    {
        //mat.SetTextureOffset(mat.GetTextureOffset())
        transforms.ForEach(transform =>{
            transform.position += Time.deltaTime* Vector3.forward;
        });
    }

    public void OnTriggerEnter(Collider other) {
        transforms.Add(other.transform);
    }
}
