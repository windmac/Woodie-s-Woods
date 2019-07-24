using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeGrow : MonoBehaviour
{
    [SerializeField] float growTime = 2f;
    [SerializeField] float fullX = 1f;
    Material myMat;
    float growPercent;

    // Start is called before the first frame update
    void Start()
    {
        myMat = GetComponent<Renderer>().material;
        growPercent = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        myMat.SetFloat("_DissolveX", growPercent);
    }

    public IEnumerator Grow()
    {
        while (growPercent > fullX)
        {
            growPercent -= Time.deltaTime / growTime;
            yield return null;
        }
        
    }
}
