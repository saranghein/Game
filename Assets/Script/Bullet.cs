using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
float time = 0.0f;
    Status status;
    public UnitCode unitCode;
    public Animator animator;
    [HideInInspector]
    public Rigidbody2D rigid2D;
    [HideInInspector]
    public bool died = false;
    [HideInInspector]
    public Collider2D col2D;
    [HideInInspector]
    public bool attacked = false;

    private void Start()
    {

    }
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 1)
        {
            Destroy(this.gameObject);// 1�� ������ �Ѿ� ������� ��
        }
    }
    void OnTriggerEnter2D(Collider2D Obj)
    {
        if (Obj.gameObject.tag.Equals("Enemy"))
        // �ε��� ��ü�� �±װ� Object���� Ȯ��(�� �߰��ϸ� enemy�� ����)
        {
            
            Destroy(this.gameObject);
            // �Ѿ��� ����
            UnitMgr _unitMgr = Obj.GetComponent<UnitMgr>();
            if (_unitMgr.status.nowHp <= 0)
            {
                animator.SetTrigger("die");
                Destroy(Obj.gameObject);
                Destroy(_unitMgr);
            }
                //UnitMgr _unitMgr2 = GetComponentInParent<UnitMgr>();
                //StartCoroutine(_unitMgr.CheckDied());

                //Debug.Log(_unitMgr.status.nowHp);

                //if (_unitMgr.attacked)
                //{
                //Destroy(GameObject.GetComponent<Bullet>);
                //_unitMgr2.status.nowHp -= _unitMgr.status.atkDmg;
                _unitMgr.status.nowHp -= 10;//status.atkDmg;
                Debug.Log(_unitMgr.status.nowHp);
            //    _unitMgr.attacked = false;
           // }

        }


    }
}