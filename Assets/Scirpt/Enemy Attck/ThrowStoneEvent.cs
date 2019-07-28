using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStoneEvent : MonoBehaviour
{
    public ShootingAttack st;

    private void shoot()
    {
        st.shoot();
    }
}
