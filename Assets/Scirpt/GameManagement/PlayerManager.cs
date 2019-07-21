using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemAndSkill
{
    Axe=0,
    WateringCan=1,
    SeedFake=2,
    SeedMushroom=3,
    SeedBoom=4,
}
public struct ItemNode
{
    public ItemAndSkill Item;
    public Transform Parent;
    public bool Active;

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
        ItemList.Add(new ItemNode(ItemAndSkill.SeedFake, Seed.transform, ItemActive[2]));
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
}
