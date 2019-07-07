using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WoodieStat : MonoBehaviour
{
    // Start is called before the first frame update
    public int max_health = 5;
    public int current_health { get; private set; }


    public GameObject player;



    public static WoodieStat instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of WoodieStat found");
            return;
        }
        instance = this;


        current_health = max_health;
    }

   


    public void takeDamage(int damage)
    {
        current_health -= damage;
        Debug.Log(player.name + "takes " + damage + " damage");

        //If health belows 0, then die
        if (current_health <= 0)
        {
            die();
        }

    }

    public void die()
    {
        Debug.Log(player.name + " Die");
        Destroy(player.gameObject);

        //Restart
        SceneManager.LoadScene("SampleScene");
    }
}
