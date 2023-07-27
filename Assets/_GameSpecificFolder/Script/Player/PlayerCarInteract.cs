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

        // Raycast ile çarpýþmayý kontrol edin
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, layerMask))
        {
            // Eðer çarpýþan obje "Seller" scriptine sahipse "carpti" mesajýný yazdýrýn
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
