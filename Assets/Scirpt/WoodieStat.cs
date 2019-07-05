using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WoodieStat : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            Destroy(this.gameObject);

            //Restart
            SceneManager.LoadScene("SampleScene");
        }
    }
}
