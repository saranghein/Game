using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    bool inputRight = false;
    bool inputLeft = false;

    UnitMgr unitMgr;
    Animator animator;
    Rigidbody2D rigid2D;
    Status status;

    void Start()
    {
        unitMgr = GetComponent<UnitMgr>();
        animator = unitMgr.animator;
        rigid2D = unitMgr.rigid2D;
        status = unitMgr.status;
    }

    void Update()
    {
        if (unitMgr.died) return;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputRight = true;
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.right *status.moveSpeed* Time.deltaTime);
            animator.SetBool("moving", true);
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputLeft = true;
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.left * status.moveSpeed* Time.deltaTime);

            animator.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //inputLeft = true;
            //transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.up * status.moveSpeed*Time.deltaTime);

            animator.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //inputLeft = true;
            //transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.down * status.moveSpeed*Time.deltaTime);

            animator.SetBool("moving", true);
        }

        else animator.SetBool("moving", false);

    }

    private void FixedUpdate()
    {
        if (unitMgr.died) return;

        if (inputRight)
        {
            inputRight = false;
            //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //rigid2D.MovePosition(rigid2D.position + Vector2.right * moveSpeed * Time.deltaTime);
            //rigid2D.velocity = new Vector2(moveSpeed, rigid2D.velocity.y);
            rigid2D.AddForce(Vector2.right * status.moveSpeed);
        }
        if (inputLeft)
        {
            inputLeft = false;
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            //rigid2D.MovePosition(rigid2D.position + Vector2.left * moveSpeed * Time.deltaTime);
            //rigid2D.velocity = new Vector2(-moveSpeed, rigid2D.velocity.y);
            rigid2D.AddForce(Vector2.left * status.moveSpeed);
        }
        if (rigid2D.velocity.x >= 1.5f) rigid2D.velocity = new Vector2(1.5f, rigid2D.velocity.y);
        else if (rigid2D.velocity.x <= -1.5f) rigid2D.velocity = new Vector2(-1.5f, rigid2D.velocity.y);
    }

    
}
