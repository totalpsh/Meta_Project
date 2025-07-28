using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : BaseController, IMoveHandler, IAttackHandler
{
    [SerializeField] private GameObject projectileSpawn;
    public GameObject projectile;
    private float spawnCooldown = 0.2f;
    private float lastShootTime;
    private Vector2 spawnPoint;

    private float moveSpeed = 5f;

    private void FixedUpdate()
    {
        Movement();
        Attack();
    }
    public void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movementDirection = new Vector2(horizontal, vertical).normalized;

        //if (horizontal > 0) _renderer.flipX = false;
        //else if (horizontal < 0) _renderer.flipX = true;

        _rigidbody.velocity = movementDirection * moveSpeed;
        _animHandler.Move(movementDirection, horizontal, vertical);
    }
    public void Attack()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time - lastShootTime >= spawnCooldown)
        {
            Shoot();
        }
    }

    private void Shoot ()
    {
        Instantiate(projectile, projectileSpawn.transform);
        lastShootTime = Time.time;
    }
}
