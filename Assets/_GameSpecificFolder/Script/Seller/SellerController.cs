using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerController : MonoBehaviour
{

    private float randomGarbainValue;

    private CarPropertiesScriptableObject carPropertiesScriptableObject;

    public void SetSellerDialog()
    {
        //dialogueSystemTrigger.conversation =  "TenantNormal" ;
        //DialogueManager.Instance.DialogueUI.Close();
        //Lua.UnregisterFunction("OpenShowRoom");

        randomGarbainValue = Random.Range(0.1f, 0.2f);
        DialogueLua.SetVariable("CarSellPrice", carPropertiesScriptableObject.CarNetPrice);
        DialogueLua.SetVariable("CarBargain", true);
        Lua.RegisterFunction("OpenSaleUI", this, SymbolExtensions.GetMethodInfo(() => OpenSaleUI()));
        Lua.RegisterFunction("BargainBuy", this, SymbolExtensions.GetMethodInfo(() => BargainBuy()));
        Lua.RegisterFunction("DirectBuy", this, SymbolExtensions.GetMethodInfo(() => DirectBuy()));
        Lua.RegisterFunction("SetBargainPrice", this, SymbolExtensions.GetMethodInfo(() => SetBargainPrice()));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.GetComponent<DialogueSystemTrigger>().OnUse();
        }
    }

    private void OpenSaleUI()
    {
        Debug.Log("OpenSaleUI");
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
        carPropertiesScriptableObject.CarNetPrice -= (int)(carPropertiesScriptableObject.CarNetPrice * randomGarbainValue);
        DialogueLua.SetVariable("CarSellPrice", carPropertiesScriptableObject.CarNetPrice);
    }

    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        //carPropertiesScriptableObject = GetComponentInParent<CarProperties>().CarPropertiesScriptableObject;
    }
}
