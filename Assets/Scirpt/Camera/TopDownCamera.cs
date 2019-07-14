using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{


        #region Variables

        public Transform target;
        public float height = 7f;
        public float distance = 11f;
        public float angle = 0f;
        #endregion

        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            HandleCamera();
        }

        // Update is called once per frame
        void Update()
        {
            HandleCamera();
        }
        #endregion


        #region Helper Methods
        protected virtual void HandleCamera()
        {
            if(!target)
            {
            return;
            }
        
        //Position vector
        Vector3 worldPosition = (Vector3.forward * -distance) + (Vector3.up * height);
        Debug.DrawLine(target.position, worldPosition, Color.red);

        //Rotator vector

        Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;
        Debug.DrawLine(target.position, rotatedVector, Color.blue);

        //Move our position
        Vector3 flatTargetPosition = target.position;
        flatTargetPosition.y = 0f;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;

        Debug.DrawLine(target.position, finalPosition, Color.green);
        transform.position = finalPosition;

        transform.LookAt(target);
        }
        #endregion

}
