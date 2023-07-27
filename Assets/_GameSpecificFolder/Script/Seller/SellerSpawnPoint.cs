using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerSpawnPoint : MonoBehaviour
{
    void Start()
    {
        SellerSpawnManager.Instance.InstantiateSeller(transform.position, transform.rotation);
    }

}
