using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPlantColorChanging : MonoBehaviour
{
    Material myMat;
    public float speed = 0.6f;
    // Start is called before the first frame update

    private float c1 =1f;
    private float c2 =1f;
    void Start()
    {
        myMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        c1 = Mathf.Lerp(c1, 0f, Time.deltaTime * speed);
        c2 = Mathf.Lerp(c2, 0f, Time.deltaTime * speed);

      /*  myMat.SetVector("_Color", new Vector4(1f,
                                             Mathf.Lerp(1f, 0f, Time.deltaTime* speed),
                                             Mathf.Lerp(1f, 0f, Time.deltaTime * speed),
                                             1f));*/
        myMat.SetVector("_Color", new Vector4(1f,c1,c2,1f));
    }
}
