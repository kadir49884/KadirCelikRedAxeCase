using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

[CreateAssetMenu(fileName = "GameDatas", menuName = "KadirExtension/GameDatas", order = 1)]
public class GameDatas : ScriptableObject
{


    [Header("Effect Of Properties On The Price")]

    public CarPriceFactors carPriceFactors;

    [Serializable]
    public class CarPriceFactors
    {
        [Range(0f, 0.5f)]
        public float DamageFactor;
        [Range(0f, 0.5f)]
        public float PaintFactor;
        [Range(1f, 10f)]
        public float SpeedFactor;
        [Range(1f, 10f)]
        public float TorqueFactor;
    }



    [Header("InteractMessage")]
    public InteractMessages interactMessages;

    [Serializable]
    public class InteractMessages
    {
        public string CarMessage;
        public string SellerMessage;
    }


    [Header("Car List")]
    public List<GameObject> CarList = new List<GameObject>();

    [Header("Seller List")]
    public List<GameObject> SellerList = new List<GameObject>();

    



    [Button]
    public void ResetGameData()
    {
        Debug.Log("GameData Reset");

        carPriceFactors.DamageFactor = 1;
        carPriceFactors.PaintFactor = 1;
        carPriceFactors.SpeedFactor = 1;
        carPriceFactors.TorqueFactor = 1;

        CarList.Clear();
        SellerList.Clear();

        interactMessages.CarMessage = "Bin";
        interactMessages.SellerMessage = "Konus";

    }
}
