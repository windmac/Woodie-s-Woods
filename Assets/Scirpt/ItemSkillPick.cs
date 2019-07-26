using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemSkillPick : MonoBehaviour
{
    public string ItemLog;
    public int Index;

    public PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Woodie")
        {
            playerManager.SetItemState(ItemLog, Index, true);
            Destroy(this.gameObject);
        }
    }
}
