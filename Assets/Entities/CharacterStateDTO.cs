

public struct CharacterStateDTO {
   
    public float fireRate; 
    public float range;

    float year; 

    float power;

    float health; 


    public static CharacterStateDTO operator +(CharacterStateDTO a , CharacterStateDTO b){

            return new CharacterStateDTO(){
                fireRate = a.fireRate + b.fireRate,
                range = a.range + b.range,
                year = a.year +b.year,
                power = a.power + b.power,
                health = a.health + b.health
            };
    }
}