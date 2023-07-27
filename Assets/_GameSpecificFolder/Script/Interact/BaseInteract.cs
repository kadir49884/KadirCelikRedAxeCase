using Sirenix.OdinInspector;
using UnityEngine;

public class BaseInteract : MonoBehaviour
{

    [SerializeField, ReadOnly] protected CanvasManager canvasManager;


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
