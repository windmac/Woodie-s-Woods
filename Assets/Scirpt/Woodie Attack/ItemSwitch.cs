using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitch : MonoBehaviour
{
    public int selectedItem = 0;
    private int num_items;

    // Start is called before the first frame update
    void Start()
    {
        SelectItem();
        num_items = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelected = selectedItem;
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (selectedItem >= num_items - 1)
                selectedItem = 0;
            else
                selectedItem++;


        }

        if(previousSelected != selectedItem)
        {
            SelectItem();
        }

    }

    void SelectItem()
    {
        int i = 0;
        foreach(Transform item in transform)
        {
            if (i == selectedItem)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
            i++;
        }
    }
}
