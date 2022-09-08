using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField][Range(1000f, 10000f)] float pitchForce = 6000f, rollForce=1000, yawForce=2000f,thrustForce =7000;
   [SerializeField][Range(-1,1)] float  yawAmount,pitchAmount,rollAmount;
   Rigidbody rb;
    [SerializeField] ShipMovementInput _movementInput;
    [SerializeField] List<ShipEngine> _engines;
    IMovementControls controlInput => _movementInput.movementControls;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        
   
        foreach(ShipEngine engine in _engines)
        {
            engine.Init(controlInput,rb,thrustForce/_engines.Count);
        }
    }

    private void FixedUpdate()
    {
        rollAmount = controlInput.RollAmount;
        yawAmount = controlInput.YawAmount;
        pitchAmount = controlInput.PitchAmount;

        if (!Mathf.Approximately(0f, pitchAmount))
        {
            rb.AddTorque(transform.right * (pitchForce * pitchAmount * Time.fixedDeltaTime));
            Debug.Log("Adding pitch force ");
        }

        if (!Mathf.Approximately(0f, rollAmount))
        {
            rb.AddTorque(transform.forward * (rollForce * rollAmount * Time.fixedDeltaTime));
            Debug.Log("Adding pitch force ");
        }
        if (!Mathf.Approximately(0f, yawAmount))
        {
            rb.AddTorque(transform.up * (yawForce * yawAmount * Time.fixedDeltaTime));
            Debug.Log("Adding pitch force ");
        }
      
    }
    private void Update()
    {
       // thrustAmount = controlInput.ThrustAmount;
      
    }
}
