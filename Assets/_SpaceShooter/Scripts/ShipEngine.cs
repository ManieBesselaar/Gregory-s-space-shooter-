using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEngine : MonoBehaviour
{
    [SerializeField] GameObject _thruster;
    IMovementControls _shipMovementControls;
    Rigidbody _thrusterRigidbody;
    float _thrustAmount =0;
    [SerializeField] float thrustForce ;
    private void Awake()
    {
       
    }
    bool thrustEnabled => !Mathf.Approximately(0f,_shipMovementControls.ThrustAmount); //Uses the movement controls interface to get the state of the ship thrust

    public void Init(IMovementControls shipMovementControls,Rigidbody _rigidbody,float thrustForce)
    {
        _thrusterRigidbody = _rigidbody;
        this.thrustForce = thrustForce;
_shipMovementControls = shipMovementControls;
    }

    void ActivateThrusters()
    {
        _thruster.SetActive(thrustEnabled);
        if (!thrustEnabled) return;
        _thrustAmount = _shipMovementControls.ThrustAmount; 
       
        if (!Mathf.Approximately(0f, _thrustAmount) && _thrustAmount > 0)
        {
           
            _thrusterRigidbody.AddForce(transform.forward * (thrustForce * _thrustAmount * Time.fixedDeltaTime), ForceMode.Impulse);
            Debug.Log("Adding thrust force ");
        }

       

    }
    private void FixedUpdate()
    {
        ActivateThrusters();
    }
    private void Update()
    {
        
    }
}
