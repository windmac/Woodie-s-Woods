using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSeed : MonoBehaviour
{
    [SerializeField] GameObject bridge;

    private void OnCollisionEnter(Collision collision)
    {
        print("Bridge starts to grow");
        StartCoroutine(bridge.GetComponent<BridgeGrow>().Grow());
    }
}
