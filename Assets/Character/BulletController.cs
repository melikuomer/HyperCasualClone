using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{


    public void InitValues(float range, float fireRate){
        movementRange = range;
        this.fireRate = fireRate; 
    }
    float movementRange = 20f;
    float fireRate = 1f;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(MoveBullet());
    }

    private void OnCollisionEnter(Collision other) {
        IHittable hittable;
           
        if(other.gameObject.TryGetComponent<IHittable>(out hittable)){
            hittable.RecieveHit();
            Destroy(gameObject);
        }
    }
  
    IEnumerator MoveBullet(){
        Vector3 startPosition = transform.position; // Starting position of the object

        // Calculate the total distance to travel
        float totalDistance = movementRange;

        Vector3 targetPosition = startPosition + Vector3.forward * movementRange; 

        // Calculate the movement per frame based on movement range and total distance
        float movementPerFrame = fireRate / totalDistance;

        // Calculate the new position for each frame
        float traveledDistance = 0f;
        while (traveledDistance < movementRange)
        {
            traveledDistance += movementPerFrame;

            // Clamp traveledDistance to avoid exceeding the range
            traveledDistance = Mathf.Clamp(traveledDistance, 0f, movementRange);

            // Use Lerp to calculate the new position based on traveled distance
            transform.position = Vector3.Lerp(startPosition, targetPosition, traveledDistance / movementRange);

            // Yield control back to Unity until the next frame
            yield return null;
        }

        // Optionally, snap to the target position after the lerp is complete
        transform.position = targetPosition;
        Destroy(gameObject);
    }
}
