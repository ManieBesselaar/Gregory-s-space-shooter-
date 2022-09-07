using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopMovementControls : MovementControlBase
{
    float _deadZone = .4f;
    Vector2 ScreenCenter = new Vector2(Screen.width * .5f, Screen.height * .5f);
    private float _rollAmount;
    private float _rollRate =2;

    public override float YawAmount {
        get {
            Vector3 mousePosition = Input.mousePosition;
            float yaw = (mousePosition.x - ScreenCenter.x) / ScreenCenter.x;
       return Mathf.Abs( yaw) > _deadZone? yaw:0f; //Check if absolute val yaw > _deadzone true: return yaw, false return 0
        }
    }
    public override float PitchAmount
    {
        get
        {
            Vector3 mousePosition = Input.mousePosition;
            float pitch = (mousePosition.y - ScreenCenter.y) / ScreenCenter.y;
            return Mathf.Abs(pitch) > _deadZone ? -pitch : 0f; //Check if absolute val yaw > _deadzone true: return yaw, false return 0
        }
    }

    public override float RollAmount { get
        {
            float roll;
            if (Input.GetKey(KeyCode.Q))
            {
                roll = 1f;
            }
            else
            {

                roll= Input.GetKey(KeyCode.E) ? -1 : 0f;
            }
            return _rollAmount = Mathf.Lerp(_rollAmount, roll, Time.deltaTime * _rollRate);    
        }
    }

    public override float ThrustAmount => Input.GetAxis("Vertical");
}
