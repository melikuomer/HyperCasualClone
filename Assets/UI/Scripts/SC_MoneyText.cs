using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SC_MoneyText : MonoBehaviour
{
    
    float money= 0;

    [SerializeField]
    TextMeshProUGUI TMP;

    public void Start(){
        SC_CharacterState.onMoneyChanged +=OnMoneyChanged;
    }
    public void OnMoneyChanged(float amount){
        money+= amount;
        TMP.text= money.ToString();
    }
}
