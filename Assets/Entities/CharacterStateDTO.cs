
using System;

[Serializable]
public struct CharacterStateDTO {
   
    public float FireRate; 
    public float Range;

    public float Year; 

    public float Power;

    public float Health; 

    public float Money; 


    

    public static CharacterStateDTO operator +(CharacterStateDTO a , CharacterStateDTO b){

            return new CharacterStateDTO(){
                FireRate = a.FireRate + b.FireRate,
                Range = a.Range + b.Range,
                Year = a.Year +b.Year,
                Power = a.Power + b.Power,
                Health = a.Health + b.Health,
                Money = a.Money + b.Money
            };
    }
    
}