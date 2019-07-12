using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectsInSight : MonoBehaviour
{
    //观察目标
    public Transform target;

    //上次碰撞到的物体
    private List<GameObject> lastColliderObject;

    //本次碰撞到的物体
    private List<GameObject> colliderObject = null;



    void LateUpdate()
    {

        if (!target)
            return;




        Vector3 aim = target.position;
        //得到方向
        Vector3 ve = (target.position - transform.position).normalized;
        float an = transform.eulerAngles.y;
        aim -= an * ve;

        Debug.DrawLine(transform.position, target.position, Color.red);

        RaycastHit hit;

        GameObject lastobj=null;

        if (Physics.Linecast(transform.position, target.position, out hit))
        {
            GameObject obj = hit.collider.gameObject;

            Debug.Log(obj.name+" "+ obj.tag + " Hide");
            string name = obj.tag;
            if (obj.gameObject.layer ==LayerMask.NameToLayer("Ground"))
            {
                
                MeshRenderer[] msrs =  obj.GetComponentsInChildren<MeshRenderer>();
                Color color;
                Texture tex;
                foreach (MeshRenderer msr in msrs)
                {
                    Material[] mats = msr.materials;

                    foreach(Material mat in mats)
                    {
                        color = mat.color;

                        color.a = 0.5f;
                        SetTransparent(mat);
                        mat.SetColor("_Color", color);
                    }


                }

                Debug.Log(obj.name + " Hidding");
                lastobj = obj;

            }
            else
            {
                if (lastobj != null)
                {
                   // Color color = lastobj.GetComponent<MeshRenderer>().material.color;
                   // color.a = 1f;
                   // lastobj.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
                }
            }
        }
    }




    public static void SetTransparent(Material standardShaderMaterial)
    {
     
                standardShaderMaterial.SetFloat("_Mode", 3);
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
             
        

    }

}
