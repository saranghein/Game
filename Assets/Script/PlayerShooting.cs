using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Rigidbody2D rigid;
    public float gunDelay;
    public float lastShoot;
    public GameObject bulletObj1;
    Vector3 MousePosition;
    Camera Camera;
    Vector2 Dir;
    public float BULLET1_SPEED = 1000;

    float angle;
    public int Ammo1 = 20;



    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        Fire();// �Ѿ��� ��� �Լ�
  
        Reload();
        ShotDelay();// �Ѿ� �߻� �� ������ �ִ� �Լ�
    }
    void Reload()
    {
        if (!Input.GetButton("Fire3"))
        {
            return;
        }
        Ammo1 = 20;
 
    }
        void ShotDelay()
        {
            lastShoot += Time.deltaTime;// ���������� ���� ��� ���� �ð��� ����
        }
        void Fire()
        {
            gunDelay = 0.2F;// ���� �ּ� ������
            if (!Input.GetButton("Fire1"))//�߻� ���ϸ� ����
            {
                return;
            }
            if (lastShoot < gunDelay)// ���������� ���� ��� ���� �ð� < ���� �ּ� �����̸� ����
            {
                return;
            }
            if (Ammo1 == 0)
            {
                return;
            }
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);// ���콺 ����
            Dir = MousePosition - transform.position;// (���콺 ���� - ĳ���� ����)�� ������ ã��
            Dir = Dir.normalized;// ���� ũ�� ����(���ϸ� ���� �����̾ �Ÿ��� ���� �Ѿ� �ӵ� �޶���)
            angle = Mathf.Atan2(MousePosition.y - transform.position.y, MousePosition.x - transform.position.x) * Mathf.Rad2Deg;
            GameObject bullet = Instantiate(bulletObj1, transform.position, Quaternion.AngleAxis(angle - 180, Vector3.forward));
            Rigidbody2D rigid_bullet = bullet.GetComponent<Rigidbody2D>();
            rigid_bullet.AddForce(Dir * BULLET1_SPEED);// Dir = ����, BULLETSPEED = �Ѿ� �ӵ�
            Ammo1--;
            lastShoot = 0;
        }
   
    }