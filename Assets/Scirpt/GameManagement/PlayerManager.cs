using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemAndSkill
{
    Axe=0,
    WateringCan=1,
    SeedShooter=2,
    SeedMushroom=3,
    SeedBoom=4,
}
public struct ItemNode
{
    public ItemAndSkill Item { get; set; }
    public Transform Parent { get; set; }
    public bool Active { get; set; }

    public ItemNode(ItemAndSkill item, Transform parent, bool active)
    {
        Item = item;
        Parent = parent;
        Active = active;
    }
}

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public static PlayerManager instance;
    public bool[] ItemActive;
    public GameObject player;

    public List<ItemNode> ItemList;
    public GameObject Seed;
    public GameObject LogUI;

    void Awake()
    {
        instance = this;
        InitializeItemList();
    }

    private void InitializeItemList()
    {
        ItemList = new List<ItemNode>();
        ItemList.Add(new ItemNode(ItemAndSkill.Axe, null, ItemActive[0]));
        ItemList.Add(new ItemNode(ItemAndSkill.WateringCan, null, ItemActive[1]));
        ItemList.Add(new ItemNode(ItemAndSkill.SeedShooter, Seed.transform, ItemActive[2]));
        ItemList.Add(new ItemNode(ItemAndSkill.SeedMushroom, Seed.transform, ItemActive[3]));
        ItemList.Add(new ItemNode(ItemAndSkill.SeedBoom, Seed.transform, ItemActive[4]));
    }

    public bool IsEmpty()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            if (ItemList[i].Active)
            {
                return true;
            }
        }
        return false;
    }

    public void SetItemState(string log,int index,bool active)
    {

        ItemList[index] = new ItemNode(ItemList[index].Item, ItemList[index].Parent, active);
        ItemActive[index] = active;
        ShowLog(log);
    }

    public void ShowLog(string log)
    {
        LogUI.GetComponent<LogUI>().ShowLog(log);
    }
}
