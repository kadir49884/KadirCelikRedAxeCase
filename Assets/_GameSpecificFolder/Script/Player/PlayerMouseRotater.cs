using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseRotater : MonoBehaviour
{

    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;

    [SerializeField] Transform cam = null;
    [SerializeField] Transform orientation = null;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation = 0;
    float yRotation = 90;

    void Start()
    {
        // Script başladığında Coroutine'i başlatın
        StartCoroutine(StartMyCoroutine());

    }
    IEnumerator StartMyCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, cam.transform.rotation.z);
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
