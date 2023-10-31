using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;

    private bool isFirstPerson = false;

    void Start() {        thirdPersonCamera.enabled = true;
        firstPersonCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isFirstPerson = !isFirstPerson;
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        thirdPersonCamera.enabled = !isFirstPerson;
        firstPersonCamera.enabled = isFirstPerson;
    }
}
