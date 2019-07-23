using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSeed : MonoBehaviour
{
    [SerializeField]
    GameObject bridge;
    [SerializeField]
    GameObject appearence;

   /* private void OnCollisionEnter(Collision collision)
    {
        print("Bridge starts to grow");
        bridge.SetActive(true);
        StartCoroutine(bridge.GetComponent<BridgeGrow>().Grow());
    }*/

    public void growth()
    {
        bridge.SetActive(true);
        StartCoroutine(bridge.GetComponent<BridgeGrow>().Grow());
        Destroy(appearence.gameObject);
        // Destroy(this.gameObject);
    }
}
