using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatingCamera : MonoBehaviour
{
    public bool isEnabled;
    public Transform positionReference;    
    public Vector3 offset;    
    public bool lookAtTarget;
    public Transform targetTransform;
    [Range(0.01f, 1.0f)]
    public float smoothFactor;

    private Camera mainCam;
    private Camera specCam;
    private AudioListener alMainCam;
    private AudioListener alSpecCam;


    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        specCam = GetComponent<Camera>();

        alMainCam = mainCam.GetComponent<AudioListener>();
        alSpecCam = specCam.GetComponent<AudioListener>();

        if (isEnabled)
            ShowSpectatingCamera();
        else
            ShowMainCamera();
    }

    
    void Update()
    {
        if (isEnabled)
            ShowSpectatingCamera();
        else
            ShowMainCamera();        
    }


    private void LateUpdate()
    {
        if (positionReference)
        {
            Vector3 newPos = positionReference.position + offset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        }        

        if (lookAtTarget && targetTransform)
            transform.LookAt(targetTransform);
    }


    public void SwapCamera()
    {
        if (isEnabled)
            ShowMainCamera();
        else
            ShowSpectatingCamera();
    }


    public void ShowMainCamera()
    {
        mainCam.enabled = true;
        alMainCam.enabled = true;

        specCam.enabled = false;
        alSpecCam.enabled = false;

        isEnabled = false;
    }


    public void ShowSpectatingCamera()
    {
        mainCam.enabled = false;
        alMainCam.enabled = false;

        specCam.enabled = true;
        alSpecCam.enabled = true;

        isEnabled = true;
    }


    public void SetPositionReference(Transform posRef)
    {
        positionReference = posRef;
    }



    public void SetTargetToLook(Transform atargetToLook)
    {
        targetTransform = atargetToLook;
    }
}
