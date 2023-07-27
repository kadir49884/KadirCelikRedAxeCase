using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField, ReadOnly] private CanvasManager canvasManager;
    private float rayLength = 2;
    private RaycastHit hit;
    private bool isActiveInteractPromptE; // For Optimization


    private void FixedUpdate()
    {

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, layerMask))
        {
            if (hit.transform.TryGetComponent(out IInteractableObject interactableObject) && !isActiveInteractPromptE)
            {
                interactableObject.RayTriggerInteractObject();
                isActiveInteractPromptE = true;
            }

        }
        else if (isActiveInteractPromptE)
        {
            canvasManager.DeactiveInteractHelper();
            isActiveInteractPromptE = false;
        }

    }

    // For Optimization
    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        if (!canvasManager)
        {
            canvasManager = CanvasManager.Instance;
        }
    }

}
