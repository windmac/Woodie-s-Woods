using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public override void interact()
    {
        base.interact();

        PickUp();
    }

    public virtual void PickUp()
    {

        Destroy(gameObject);
    }
}
