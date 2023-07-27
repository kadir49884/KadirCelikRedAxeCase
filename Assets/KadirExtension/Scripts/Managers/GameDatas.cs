using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;



[CreateAssetMenu(fileName = "GameDatas", menuName = "KadirExtension/GameDatas", order = 1)]
public class GameDatas : ScriptableObject
{


    [Header("Effect Of Properties On The Price")]
    [Range(0f, 0.5f)]
    public float DamageFactor;
    [Range(0f, 0.5f)]
    public float PaintFactor;
    [Range(1f, 10f)]
    public float SpeedFactor;
    [Range(1f, 10f)]
    public float TorqueFactor;


    [Button]
    public void ResetGameData()
    {
        Debug.Log("GameData Reset");

        DamageFactor = 1;
        PaintFactor = 1;
        SpeedFactor = 1;
        TorqueFactor = 1;

    }
}
