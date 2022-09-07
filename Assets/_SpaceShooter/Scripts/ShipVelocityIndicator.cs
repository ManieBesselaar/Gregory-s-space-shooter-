using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipVelocityIndicator : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    Vector3 currentVelocity ;
    private void FixedUpdate()
    {
       currentVelocity= rb.velocity;
      float velocityAngle =  Vector3.Angle(transform.forward, currentVelocity.normalized);
    
        Debug.Log("Ship velocity = " +rb.velocity +" " + velocityAngle);
    }
}
