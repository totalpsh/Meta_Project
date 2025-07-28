using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _renderer;

    protected Rigidbody2D _rigidbody;
    protected AnimationHandler _animHandler;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animHandler = GetComponent<AnimationHandler>();
    }
}
