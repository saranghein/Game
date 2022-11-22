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
        Fire();// 총알을 쏘는 함수
  
        Reload();
        ShotDelay();// 총알 발사 간 간격을 주는 함수
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
            lastShoot += Time.deltaTime;// 마지막으로 총을 쏘고 지난 시간을 구함
        }
        void Fire()
        {
            gunDelay = 0.2F;// 총의 최소 딜레이
            if (!Input.GetButton("Fire1"))//발사 안하면 종료
            {
                return;
            }
            if (lastShoot < gunDelay)// 마지막으로 총을 쏘고 지난 시간 < 총의 최소 딜레이면 종료
            {
                return;
            }
            if (Ammo1 == 0)
            {
                return;
            }
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);// 마우스 벡터
            Dir = MousePosition - transform.position;// (마우스 벡터 - 캐릭터 벡터)로 방향을 찾음
            Dir = Dir.normalized;// 벡터 크기 조정(안하면 같은 방향이어도 거리에 따라 총알 속도 달라짐)
            angle = Mathf.Atan2(MousePosition.y - transform.position.y, MousePosition.x - transform.position.x) * Mathf.Rad2Deg;
            GameObject bullet = Instantiate(bulletObj1, transform.position, Quaternion.AngleAxis(angle - 180, Vector3.forward));
            Rigidbody2D rigid_bullet = bullet.GetComponent<Rigidbody2D>();
            rigid_bullet.AddForce(Dir * BULLET1_SPEED);// Dir = 방향, BULLETSPEED = 총알 속도
            Ammo1--;
            lastShoot = 0;
        }
   
    }