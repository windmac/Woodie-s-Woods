using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSwitch : MonoBehaviour
{
    public int selectedItem = 0;
    private int num_items;
    public Text EquipmentUI_text;
    private PlayerController2 pc;
  //  public KeyCode switch_key = KeyCode.L;
   // public KeyCode use_key = KeyCode.J;

    public bool use_item = false;
    // Start is called before the first frame update
    void Start()
    {
        SelectItem();
        num_items = transform.childCount;
        pc = gameObject.GetComponentInParent(typeof(PlayerController2)) as PlayerController2;

    }

    // Update is called once per frame
    void Update()
    {
        if(KeyMappingManager.instance.item_switch && PlayerManager.instance.IsEmpty()&&pc.canMove)
        {
            SelectNextItem();
        }

    }

    void SelectItem()
    {
        int i = 0;
        foreach(Transform item in transform)
        {
            bool itemactive = false;
            if (i>=2)
            {
                for (int j = 2; j < PlayerManager.instance.ItemList.Count; j++)
                {
                    if (PlayerManager.instance.ItemList[j].Active)
                    {
                        itemactive = true;
                    }
                }
            }
            else
            {
                itemactive = PlayerManager.instance.ItemList[i].Active;
            }
            if (i == selectedItem && itemactive)
            {
                item.gameObject.SetActive(true);
                EquipmentUI_text.text = "装备：" + item.name;
            }
            else if (i == selectedItem && !itemactive)
            {
                SelectNextItem();
            }
            else
            {
                item.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void SelectNextItem()
    {
        int previousSelected = selectedItem;
        if (selectedItem >= num_items - 1)
            selectedItem = 0;
        else
            selectedItem++;

        if (previousSelected != selectedItem)
        {
            SelectItem();
        }
    }
}
