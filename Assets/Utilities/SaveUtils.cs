using UnityEngine;
using System.Reflection;
using Unity.VisualScripting;

public class SaveUtils{

public static float ERROR_CODE = -999;
    public static void SaveState(CharacterStateDTO stateDTOpersistent){
        var fields = typeof(CharacterStateDTO).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo field in fields){
           
            PlayerPrefs.SetFloat(field.Name, (float)field.GetValue(stateDTOpersistent));
        }

    }

    public static void LoadState(ref CharacterStateDTO stateDTO ){
        object stateDTOpersistent = new CharacterStateDTO();
      
        var fields = typeof(CharacterStateDTO).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo field in fields){
            float value =  PlayerPrefs.GetFloat(field.Name);            
            field.SetValue(stateDTOpersistent, value);
        }
        
        stateDTO += (CharacterStateDTO) stateDTOpersistent;
    }

}