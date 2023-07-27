using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarInteract : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private float rayLength = 10;
    private Ray ray;
    private RaycastHit hit;

    private void FixedUpdate()
    {

        // Raycast ile �arp��may� kontrol edin
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, layerMask))
        {
            // E�er �arp��an obje "Seller" scriptine sahipse "carpti" mesaj�n� yazd�r�n
            if (hit.transform.TryGetComponent(out SellerController sellerController))
            {
                Debug.Log("carpti");
            }
            else
            {
                Debug.Log("degil");
            }
        }

    }
}
