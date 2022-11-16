using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    UnitMgr tagetUnitMgr;
    float attackDelay;
    Animator animator;
    UnitMgr unitMgr;
    Status status;

    void Start()
    {
        unitMgr = GetComponent<UnitMgr>();
        tagetUnitMgr = target.GetComponent<UnitMgr>();
        animator = unitMgr.animator;
        status = unitMgr.status;
    }

    void Update()
    {
        if (unitMgr.died || tagetUnitMgr.died) return;

        attackDelay -= Time.deltaTime;
        if (attackDelay < 0) attackDelay = 0;

        float distance = Vector3.Distance(transform.position, target.position);

        if (attackDelay == 0 && distance <= status.fieldOfVision)
        {
            // �ٶ󺸱�
            FaceTarget();

            // �������� �� ����
            if (distance <= status.atkRange)
            {
                AttackTarget();
            }
            else
            {
                // ����
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    MoveToTarget();
                }
            }
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveToTarget()
    {
        float dir = target.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        transform.Translate(new Vector2(dir, 0) * status.moveSpeed * Time.deltaTime);
        animator.SetBool("moving", true);
    }

    void FaceTarget()
    {
        if (target.position.x - transform.position.x < 0) // Ÿ���� ���ʿ� ���� ��
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // Ÿ���� �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void AttackTarget()
    {
        print("����");
        target.GetComponent<UnitMgr>().status.nowHp -= status.atkDmg;
        animator.SetTrigger("attack");
        attackDelay = status.atkSpeed; // ������ ����
    }
}