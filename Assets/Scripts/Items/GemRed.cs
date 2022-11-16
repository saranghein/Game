using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRed : MonoBehaviour
{
    // ü�� 50 ȸ��
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            UnitMgr swordMan = col.GetComponent<UnitMgr>();
            swordMan.status.nowHp += 50;
            if (swordMan.status.nowHp > swordMan.status.maxHp) 
                swordMan.status.nowHp = swordMan.status.maxHp;
            Destroy(gameObject);
        }
    }
}