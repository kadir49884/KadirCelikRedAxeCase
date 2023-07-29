using EPOOutline;
using Sirenix.OdinInspector;
using UnityEngine;

public class InteractSeller : BaseInteract, IInteractable
{

    [SerializeField, ReadOnly] private Outlinable outlinable;
    [SerializeField, ReadOnly] private SellerController sellerController;
    PlayerMouseRotater playerMouseRotater;

    private void Awake()
    {
        gameDatas = DataOperations.Instance.gameDatas;
        playerMouseRotater = PlayerDriveChecker.Instance.GetComponent<PlayerMouseRotater>();
        canvasManager = CanvasManager.Instance;
        interactManager = InteractManager.Instance;
    }

    public void InInteractObject()
    {
        canvasManager.ActiveInteractHelper(gameDatas.interactMessages.SellerMessage);
        interactManager.RegisterEnterInteractAction(InteractRun);
        outlinable.enabled = true;

    }
    public void OutInteractObject()
    {
        interactManager.UnregisterEnterInteractAction(InteractRun);
        outlinable.enabled = false;
    }

    public void InteractRun()
    {
        sellerController.StartSellerDialog();
        playerMouseRotater.enabled = false;
    }



    // For Optimization
    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        outlinable = transform.parent.GetComponent<Outlinable>();
        sellerController = transform.parent.GetComponent<SellerController>();
        
        
    }

}
