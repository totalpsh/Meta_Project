using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMove = Animator.StringToHash("IsMove");
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    protected Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 obj, float horizontal, float vertical)
    {
        animator.SetBool(IsMove, obj.magnitude > 0.5f);
    }

    public void Dead()
    {
        animator.SetBool(IsDead, true);
    }
}
