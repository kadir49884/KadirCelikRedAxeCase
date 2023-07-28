using Sirenix.OdinInspector;
using UnityEngine;

public class BaseInteract : MonoBehaviour
{

    [SerializeField, ReadOnly] protected CanvasManager canvasManager;
    [SerializeField, ReadOnly] protected GameDatas gameDatas;
    [SerializeField, ReadOnly] protected InteractManager interactManager;

}
