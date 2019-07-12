using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera2 : MonoBehaviour
{
    enum CameraMode
    {
        Normal=0,
        Talk=1,
    }
    // Start is called before the first frame update

    public Transform target;

    public Vector3 offset;
    public float normalPitch = 1f;
    public float talkPitch = 0.5f;

    public float zoomSpeed = 5f;
    public float minZoom = 1f;
    public float maxZoom = 20f;
    public float normalZoom = 5f;
    public float talkZoom = 1f;

    private CameraMode cameraMode = CameraMode.Normal;
    private float currentPitch = 1f;
    private float currentZoom = 5f;
    private float normalZoomMemory = 5f;

    void Update()
    {
        if (cameraMode==CameraMode.Normal)
        {
            normalZoomMemory -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            normalZoomMemory = Mathf.Clamp(normalZoomMemory, minZoom, maxZoom);
            currentZoom = Mathf.Lerp(currentZoom, normalZoomMemory, Time.deltaTime * zoomSpeed);
            currentPitch = Mathf.Lerp(currentPitch, normalPitch, Time.deltaTime * 5f);
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        }
        else if(cameraMode==CameraMode.Talk)
        {
            currentZoom = Mathf.Lerp(currentZoom, talkZoom, Time.deltaTime * zoomSpeed);
            currentPitch = Mathf.Lerp(currentPitch, talkPitch, Time.deltaTime * 5f);
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        }
        
    }

    void LateUpdate()
    {
        if(target!=null)
        {
            transform.position = target.position - offset * currentZoom;
            transform.LookAt(target.position + Vector3.up * currentPitch);
           // ViewObstructed();
        }

    }

    public void SetCameraMode(int mode)
    {
        if (mode!=0)
        {
            normalZoomMemory = currentZoom;
        }
        cameraMode =(CameraMode) mode;
    }




}
