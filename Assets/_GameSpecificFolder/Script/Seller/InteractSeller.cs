using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSeller : BaseInteract, IInteractableObject
{

    public void RayTriggerInteractObject()
    {
        canvasManager.ActiveInteractHelper();
    }

  
}
