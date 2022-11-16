using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            UnitMgr swordMan = col.GetComponent<UnitMgr>();
            swordMan.status.nowHp -= 10;
            if (swordMan.status.nowHp < 0) swordMan.status.nowHp = 0;
        }
    }
}
