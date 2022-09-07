using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementInput : MonoBehaviour
{
    [SerializeField] ShipInputManager.InputType  _inputType = ShipInputManager.InputType.HumanDesktop;
   public  IMovementControls movementControls { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        movementControls = ShipInputManager.GetInputControls(_inputType);
    }

    private void OnDestroy()
    {
        movementControls = null;
    }
}
