using DG.Tweening;
using PixelCrushers;
using PixelCrushers.DialogueSystem;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerController : MonoBehaviour
{

    private float randomGarbainValue;
    private CarPropertiesScriptableObject carPropertiesScriptableObject;
    [SerializeField, ReadOnly] private DialogueSystemTrigger dialogueSystemTrigger;
    private InteractCar interactCar;
    PlayerMouseRotater playerMouseRotater;

    private bool isSaveData;

    public CarPropertiesScriptableObject CarPropertiesScriptableObject { get => carPropertiesScriptableObject; set => carPropertiesScriptableObject = value; }

    private void Awake()
    {
        playerMouseRotater = PlayerDriveChecker.Instance.GetComponent<PlayerMouseRotater>();
    }



    public void StartSellerDialog()
    {
        CursorControl.SetCursorActive(true);
        SetSellerDialog();
        dialogueSystemTrigger.OnUse();
    }

    public void SetSellerDialog()
    {
        //dialogueSystemTrigger.conversation =  "TenantNormal" ;
        //DialogueManager.Instance.DialogueUI.Close();
        //Lua.UnregisterFunction("OpenShowRoom");

        if (isSaveData)
        {
            return;
        }
        isSaveData = true;
        randomGarbainValue = Random.Range(0.1f, 0.2f);
        DialogueLua.SetVariable("CarSellPrice", carPropertiesScriptableObject.CarNetPrice);
        DialogueLua.SetVariable("CarBargain", true);
        Lua.RegisterFunction("BargainBuy", this, SymbolExtensions.GetMethodInfo(() => BargainBuy()));
        Lua.RegisterFunction("DirectBuy", this, SymbolExtensions.GetMethodInfo(() => DirectBuy()));
        Lua.RegisterFunction("SetBargainPrice", this, SymbolExtensions.GetMethodInfo(() => SetBargainPrice()));
        DialogueManager.instance.conversationEnded += OnConversationEnd;
    }


    public void UnRegisterDialog()
    {
        if (!isSaveData)
        {
            return;
        }
        isSaveData = false;
        Lua.UnregisterFunction("BargainBuy");
        Lua.UnregisterFunction("DirectBuy");
        Lua.UnregisterFunction("SetBargainPrice");

    }

    public void OnConversationEnd(Transform actor)
    {
        playerMouseRotater.enabled = true;
        CursorControl.SetCursorActive(false);
        UnRegisterDialog();
    }

    private void BargainBuy()
    {
        Debug.Log("BargainBuy");
        interactCar.IsPlayerCar = true;
        DOVirtual.DelayedCall(2, () =>
        {
            gameObject.SetActive(false);

        });
    }
    private void DirectBuy()
    {
        Debug.Log("DirectBuy");
        interactCar.IsPlayerCar = true;
        DOVirtual.DelayedCall(2, () =>
        {
            gameObject.SetActive(false);

        });

    }


    private void SetBargainPrice()
    {
        carPropertiesScriptableObject.CarNetPrice -= (int)(carPropertiesScriptableObject.CarNetPrice * randomGarbainValue);
        DialogueLua.SetVariable("CarSellPrice", carPropertiesScriptableObject.CarNetPrice);
    }

    public void GetCarProperties(Transform getCar)
    {
        carPropertiesScriptableObject = getCar.GetComponent<CarProperties>().CarPropertiesScriptableObject;
        interactCar = getCar.GetComponent<CarManager>().InteractCar;
    }

    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        dialogueSystemTrigger = GetComponent<DialogueSystemTrigger>();
        //carPropertiesScriptableObject = GetComponentInParent<CarProperties>().CarPropertiesScriptableObject;
    }
}
