using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCockpitControls : MonoBehaviour
{
    [SerializeField] Transform _joystick;
   [SerializeField] Vector3 _joystickRange = Vector3.one;
   [SerializeField] List<Transform> _throttles;
    [SerializeField]float _throttleRange = 30f;
    [SerializeField]List<Transform> _rudderPedals;
    [SerializeField] float _rudderRange = 30f;

    [SerializeField] ShipMovementInput _movementInput;
    IMovementControls _controlInput => _movementInput.movementControls;


    private void Update()
    {
        AnimateJoystick();

        AnimateRudder();
        AnimateThrottle();
    }

    private void AnimateThrottle()
    {
        foreach(Transform throttleHandle in _throttles)
        {
            throttleHandle.localRotation = Quaternion.Euler(_controlInput.ThrustAmount * _throttleRange, 0, 0);
        }
    }

    private void AnimateRudder()
    {
        int pedalDirection = 1;
       foreach(Transform rudderPedal in _rudderPedals)
        {
            rudderPedal.localRotation = Quaternion.Euler(_controlInput.YawAmount * _rudderRange * pedalDirection, 0, 0);
            pedalDirection *= -1;
        }
    }

    private void AnimateJoystick()
    {
        _joystick.localRotation = Quaternion.Euler(_controlInput.PitchAmount * _joystickRange.x,
           0,
            _controlInput.RollAmount * _joystickRange.z);
    }
}
