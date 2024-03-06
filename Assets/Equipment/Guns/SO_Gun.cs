using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(menuName = "Equipment/Glove")]
public class SO_Gun : ScriptableObject
{
    [SerializeField]
    public GameObject gameObject;
    [SerializeField]
    public CharacterStateDTO gunStats;


    
}