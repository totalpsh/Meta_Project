using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlappyController : BaseController, IJumpHandler
{
    private float flapForce = 6f;
    private float forwardSpeed = 3f;
    private bool isDead = false;
    private float deathCooldown = 0;

    private bool isFlap = false;

    private void Update()
    {
        if (isDead)
        {
            if(deathCooldown <= 0)
            {
                // 버튼으로 재시작 종료 만들기
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }
    private void FixedUpdate()
    {
        Jump();
    }

    public void Jump()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;

        velocity.x = forwardSpeed;
        if(isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        _animHandler.Dead();
        isDead = true;
        deathCooldown = 1f;

        GameManager.Instance.GameOver();
        //GameManager.Instance.SetHomeBest();

    }
}
