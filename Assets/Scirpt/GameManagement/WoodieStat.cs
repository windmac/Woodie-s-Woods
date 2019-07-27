using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WoodieStat : MonoBehaviour
{

    // Start is called before the first frame update
    public int max_health = 5;
    public int current_health { get; private set; }
    public Vector3 RebornPosition;

   // public ItemSwitch equipment_system;

    public GameObject player;
    public Text HealthUI_text;
    public GameObject TalkUIParent;
    public GameObject TalkUIPrefab;
    public string TextPath;
    public string TextID;
  

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

        //UI initialization
        HealthUI_text.text = "生命值：" + current_health;
    }

   


    public void takeDamage(int damage)
    {
        current_health -= damage;
        ShowHealth();
        //If health belows 0, then die
        if (current_health <= 0)
        {
            die();
        }
    }

    private void ShowHealth()
    {
        HealthUI_text.text = "生命值：" + current_health;
    }

    public void die()
    {
        /*Debug.Log(player.name + " Die");
        Destroy(player.gameObject);

        //Restart
        SceneManager.LoadScene("SampleScene");*/
        Reborn();

    }

    private void Reborn()
    {
        player.GetComponent<PlayerController2>().canMove = false;
        player.transform.position = RebornPosition;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        current_health = max_health;
        ShowHealth();
        ShowTips();
    }

    private void ShowTips()
    {
        GameObject talkUI = Instantiate(TalkUIPrefab, TalkUIParent.transform);
        string[] textID = TextID.Split(',');
        talkUI.GetComponent<TalkUI>().ShowText(TextPath, textID, this.gameObject);
    }

    public void OnTalkFinished()
    {
        player.GetComponent<PlayerController2>().canMove = true;
    }
}
