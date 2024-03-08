using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_UpgradeMenu : MonoBehaviour
{
    [SerializeField]
    public CharacterStateDTO stateDTO= new();

    public void onFireRateButton_clicked(){
        SC_CharacterState.persistentState.FireRate +=stateDTO.FireRate;
    }
    public void onYearButton_clicked(){
        SC_CharacterState.persistentState.Year +=stateDTO.Year;
    }
    public void onMoreWeaponButton_clicked(){
        GameObject.FindWithTag("Player").GetComponentInChildren<SC_GunManager>().AddGun();
    }
    public void onGloveUpgradeButton_clicked(){
       // SC_CharacterState.persistentState.FireRate =+stateDTO.FireRate;
    }

    public void onMoreCannonButton_clicked(){
        GameObject.FindWithTag("Player").GetComponentInChildren<SC_GunManager>().AddCannon();
    }
}
