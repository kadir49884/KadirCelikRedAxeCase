using Sirenix.OdinInspector;
using UnityEngine;

public class InteractCar : BaseInteract, IInteractable
{
    [SerializeField, ReadOnly] private RCC_CarControllerV3 rCC_CarControllerV3;
    [SerializeField, ReadOnly] private DriveManager driveManager;
    [SerializeField, ReadOnly] private Transform camPosInCar;
    [SerializeField, ReadOnly] private Transform getOutPos;

    public void InInteractObject()
    {
        canvasManager.ActiveInteractHelper(gameDatas.interactMessages.CarMessage);
        interactManager.RegisterEnterInteractAction(EnterInteract);
    }

    public void OutInteractObject()
    {
        interactManager.UnregisterEnterInteractAction(EnterInteract);
    }

    public void EnterInteract()
    {
        if (!rCC_CarControllerV3.enabled)
        {
            Debug.Log("EnterInteractCar");
            driveManager.GetInCar(transform.parent, camPosInCar);
            rCC_CarControllerV3.enabled = true;
        }
        else
        {
            Debug.Log("ExitInteractCar");
            rCC_CarControllerV3.enabled = false;
            driveManager.GetOutCar(getOutPos);

        }
    }


    // For Optimization

    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        rCC_CarControllerV3 = transform.parent.GetComponent<RCC_CarControllerV3>();
        camPosInCar = transform.parent.GetComponentInChildren<CameraPosInCar>().transform;
        getOutPos = transform.parent.GetComponentInChildren<GetOutPosCar>().transform;
        driveManager = DriveManager.Instance;
        canvasManager = CanvasManager.Instance;
        interactManager = InteractManager.Instance;
        gameDatas = DataOperations.Instance.gameDatas;
    }


}
