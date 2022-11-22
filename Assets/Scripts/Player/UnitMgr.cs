using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitMgr : MonoBehaviour
{
    public Animator animator;
    [HideInInspector]
    public Rigidbody2D rigid2D;
    [HideInInspector]
    public bool died = false;
    [HideInInspector]
    public Collider2D col2D;
    [HideInInspector]
    public bool attacked = false;
    
    public Status status;

    public UnitCode unitCode;
    public Healthbar healthBar;
    public Hungrybar hungrybar;
    //public Thirstbar thirstbar;
    float timeSpanHunger = 0.0f;
    //float timeSpanThirst = 0.0f;
    float updateTimeHunger = 3.0f;
    //float updateTimeThirst = 4.0f;
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<Collider2D>();

        // 스테이터스 설정
        status = new Status();
        status = status.SetUnitStatus(unitCode);
        healthBar.SetMaxHealth(status.maxHp);
        hungrybar.SetMaxHungry(status.maxHunger);
        //thistbar.SetMaxThirst(status.maxThirst);
        SetAttackSpeed(status.atkSpeed);
        StartCoroutine(CheckDied());
    }
    private void Update()
    {
        healthBar.SetHealth(status.nowHp);
        timeSpanHunger += Time.deltaTime;
        //timeSpanThirst+=Time.deltaTime;
        if (timeSpanHunger > updateTimeHunger)
        {
            status.nowHunger -= 10;
            hungrybar.SetHungry(status.nowHunger);
            timeSpanHunger = 0;
        }
        //if (timeSpanThirst > updateTimeThirst)
        //{
        //    status.nowHunger -= 20;
        //    hungrybar.SetHungry(status.nowHunger);
        //    timeSpanThirst = 0;
        //}

    }

    IEnumerator CheckDied()
    {

        while (true)
        {

            // 체력이 0이하일 때
            if (status.nowHp <= 0||status.nowHunger<=0||status.nowThirst<=0)
            {
                Debug.Log("die");

                died = true;
                animator.SetTrigger("die");
                Destroy(rigid2D);
                Destroy(col2D);
                yield return new WaitForSeconds(2); // 2초 기다리기
                if (unitCode.Equals(UnitCode.swordman))
                    SceneManager.LoadScene("GameScene"); // Scene 재시작
                else if (unitCode.Equals(UnitCode.enemy1))
                    //Debug.Log("die");
                    Destroy(gameObject);
            }
            yield return new WaitForEndOfFrame(); // 매 프레임의 마지막 마다 실행
        }
    }
    /*
    void OnTriggerEnter2D(Collider2D col)//Player가 공격시
    {
        if (tag.Equals("Enemy"))//상대방이 Enemy
        {
            if (col.CompareTag("Weapon"))
            //if(col.gameObject.BulletObj)
            {
                UnitMgr _unitMgr = col.GetComponentInParent<UnitMgr>();
                if (_unitMgr.attacked)
                {
                    //Destroy(GameObject.GetComponent<Bullet>);
                    status.nowHp -= _unitMgr.status.atkDmg;
                    _unitMgr.attacked = false;
                }
            }
        }
    
    }*/

    #region properties

    public void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        status.atkSpeed = speed;
    }

    public float GetAttackSpeed()
    {
        return status.atkSpeed;
    }

    public void SetMoveSpeed(float speed)
    {
        status.moveSpeed = speed;
    }
    public float GetMoveSpeed()
    {
        return status.moveSpeed;
    }

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }

    #endregion

}
