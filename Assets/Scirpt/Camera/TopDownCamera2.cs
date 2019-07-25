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
    private Vector3 temp_position;
    private bool temp_set = false;
    public GameObject talking_target;
    public Transform talk_point;
    public float talking_offset = 10f;
    public Vector3 talking_offest_adjestment;

    public float camera_moving_speed = 5f;

    void Update()
    {
        if (cameraMode==CameraMode.Normal)
        {
            normalZoomMemory -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            normalZoomMemory = Mathf.Clamp(normalZoomMemory, minZoom, maxZoom);
            currentZoom = Mathf.Lerp(currentZoom, normalZoomMemory, Time.deltaTime * zoomSpeed);
            currentPitch = Mathf.Lerp(currentPitch, normalPitch, Time.deltaTime * camera_moving_speed);
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        }
        else if(cameraMode==CameraMode.Talk)
        {
            

            currentZoom = Mathf.Lerp(currentZoom, talkZoom, Time.deltaTime * zoomSpeed);
            currentPitch = Mathf.Lerp(currentPitch, talkPitch, Time.deltaTime * camera_moving_speed);
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

           
        }
        
    }

    void LateUpdate()
    {


        if (cameraMode == CameraMode.Talk)
        {
            if(!temp_set)
            {

            temp_position = GetPointDistanceFromObject(talking_target.transform.position, talk_point.position, talking_offset)
                                      +talking_target.transform.TransformVector(talking_offest_adjestment.x, talking_offest_adjestment.y, talking_offest_adjestment.z) ;
            temp_set = true;
            }

            if (talking_target!=null)
            {


                transform.position = Vector3.Lerp(transform.position, temp_position, Time.deltaTime * camera_moving_speed);


                transform.LookAt(Vector3.Lerp(transform.position, talking_target.transform.position, Time.deltaTime * camera_moving_speed));

            }
        }else if(target != null)
        {
            transform.position = Vector3.Lerp(transform.position,target.position - offset * currentZoom, Time.deltaTime * camera_moving_speed);
            transform.LookAt(target.position + Vector3.up * currentPitch);
            temp_position = transform.position;
            temp_set = false;
        }else
        {
            temp_set = false;
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

    
   

    Vector3 GetPointDistanceFromObject(Vector3 objectposition, Vector3 basePosition, float distance)
    {
        Vector3 directionOfTravel = basePosition - objectposition;

        Vector3 finalDirection = directionOfTravel + directionOfTravel.normalized * distance;

        Vector3 targetPosition = objectposition + finalDirection;

        return targetPosition;
    }


}
