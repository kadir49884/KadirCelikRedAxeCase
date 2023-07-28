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
    [SerializeField, ReadOnly] PlayerMouseRotater playerMouseRotater;

    private bool isSaveData;



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
        //DialogueLua.SetVariable("CarSellPrice", carPropertiesScriptableObject.CarNetPrice);
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
    }
    private void DirectBuy()
    {
        Debug.Log("DirectBuy");
    }

    private void SetBargainPrice()
    {
        //carPropertiesScriptableObject.CarNetPrice -= (int)(carPropertiesScriptableObject.CarNetPrice * randomGarbainValue);
        //DialogueLua.SetVariable("CarSellPrice", carPropertiesScriptableObject.CarNetPrice);
    }

    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        dialogueSystemTrigger = GetComponent<DialogueSystemTrigger>();
        playerMouseRotater = PlayerDriveChecker.Instance.GetComponent<PlayerMouseRotater>();
        //carPropertiesScriptableObject = GetComponentInParent<CarProperties>().CarPropertiesScriptableObject;
    }
}
