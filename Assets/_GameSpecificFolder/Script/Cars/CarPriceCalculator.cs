using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPriceCalculator : MonoBehaviour
{
    [SerializeField, ReadOnly] private CarPropertiesScriptableObject carPropertiesScriptableObject;
    [SerializeField, ReadOnly] private GameDatas gameDatas;

    private float priceHelper;


    private void Awake()
    {
        carPropertiesScriptableObject = GetComponent<CarProperties>().CarPropertiesScriptableObject;
        gameDatas = DataOperations.Instance.gameDatas;
    }


    public void PriceCalculate()
    {
        carPropertiesScriptableObject.CarNetPrice = (int)(carPropertiesScriptableObject.CarMarketPrice
            - DamagePriceCalculate()
            - PaintPriceCalculate()
            + SpeedPriceCalculate()
            + TorqueSpeedPriceCalculate());

    }

    private float DamagePriceCalculate()
    {
        priceHelper = carPropertiesScriptableObject.CarMarketPrice
            * (carPropertiesScriptableObject.DamageValue) * gameDatas.DamageFactor;
        return priceHelper;
    }
    private float PaintPriceCalculate()
    {
        priceHelper = carPropertiesScriptableObject.CarMarketPrice
            * (carPropertiesScriptableObject.PaintValue) * gameDatas.PaintFactor;
        return priceHelper;
    }
    private float SpeedPriceCalculate()
    {
        priceHelper = carPropertiesScriptableObject.SpeedValue * gameDatas.SpeedFactor;
        return priceHelper;
    }
    private float TorqueSpeedPriceCalculate()
    {
        priceHelper = carPropertiesScriptableObject.Torquevalue * gameDatas.TorqueFactor;
        return priceHelper;
    }


}
