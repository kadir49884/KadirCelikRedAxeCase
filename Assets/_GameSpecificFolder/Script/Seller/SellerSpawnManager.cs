using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerSpawnManager : Singleton<SellerSpawnManager>
{
    private GameObject instantiateHelper;
    private int sellerCounter = 0;

    [SerializeField, ReadOnly] private GameDatas gameDatas;

    public void InstantiateSeller(Vector3 spawnPos, Quaternion getQuaternion)
    {
        if (sellerCounter >= gameDatas.SellerList.Count)
        {
            return;
        }

        instantiateHelper = Instantiate(gameDatas.SellerList[sellerCounter]);
        instantiateHelper.transform.position = spawnPos;
        instantiateHelper.transform.rotation = getQuaternion;
        sellerCounter++;
    }

    // For Optimization

    private void OnValidate()
    {
        SetRef();
    }

    public void SetRef()
    {
        gameDatas = DataOperations.Instance.gameDatas;
    }


}
