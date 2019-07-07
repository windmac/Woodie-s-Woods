using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void interact()
    {
        base.interact();

        PickUp();
    }

    public virtual void PickUp()
    {
        

        bool wasPicked = Inventory.instance.Add(item);

        if (wasPicked)
        {
            Destroy(gameObject);
        }

    }
}
