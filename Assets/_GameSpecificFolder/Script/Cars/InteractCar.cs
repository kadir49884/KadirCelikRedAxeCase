using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCar : BaseInteract, IInteractableObject
{

    public void RayTriggerInteractObject()
    {
        canvasManager.ActiveInteractHelper();

    }
    
}
