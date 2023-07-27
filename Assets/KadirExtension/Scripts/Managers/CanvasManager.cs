using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private GameObject interactPromptE;

    public void ActiveInteractHelper()
    {
        interactPromptE.SetActive(true);
    }
    public void DeactiveInteractHelper()
    {
        interactPromptE.SetActive(false);
    }

    
}
