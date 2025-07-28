using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : BaseController, IMoveHandler
{
    private float moveSpeed = 3f;

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movementDirection = new Vector2(horizontal, vertical).normalized;

        if (horizontal > 0) _renderer.flipX = false;
        else if (horizontal < 0) _renderer.flipX = true;

        _rigidbody.velocity = movementDirection * moveSpeed;
        _animHandler.Move(movementDirection, horizontal, vertical);
    }
}
