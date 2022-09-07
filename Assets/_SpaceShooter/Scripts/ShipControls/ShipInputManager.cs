using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInputManager : MonoBehaviour
{    
    public enum InputType
    {
        HumanDesktop,
        HumanMobile,
        Bot
    }
    public static IMovementControls GetInputControls(InputType inputType)
    {
        return inputType switch //new way to do switches in c#8 
        {
            InputType.HumanDesktop => new DesktopMovementControls(), //first case 
            InputType.Bot => new BotMovementControls(),//second
            InputType.HumanMobile => new HumanMobileMovementControls(),//third
            _ => throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null) //default indicated by underscore
        };
    }
}
