using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    UnitMgr unitMgr;

    void Start()
    {
        unitMgr = GetComponent<UnitMgr>();
        animator = unitMgr.animator;
    }

    void Update()
    {
        if (unitMgr.died) return;

        if (Input.GetAxis("Fire1")==1 &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
            SFXManager.Instance.PlaySound(SFXManager.Instance.playerAttack);
        }
    }
}
