using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera: MonoBehaviour
{
    private enum Mode 
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
    }

    [SerializeField] private Mode mode;
    // run after the regular Update
    private void LateUpdate()
    {
        switch (mode)
        {
            case Mode.LookAt:
                // Camera.main is now cached by default on the Unity backend
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                // direction pointing from the camera
                Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirFromCamera);
                break;
            case Mode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.CameraForwardInverted:
                transform.forward = - Camera.main.transform.forward;
                break;
        }
    }
}
