using Assets.Scripts.Interfaces;
using ClientFramework;
using GameUtilitys.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Animator animator;

    [HideInInspector]
    public Func<ISurrounding, float> getMoveDirection;

    [HideInInspector]
    public ISurrounding Surrounding { get; private set; } = new PlayerSurrounding();

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoint.position.x, transform.position.y), moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.2f)
        {
            CheckSurrounding();
            var inputX = getMoveDirection is null ? 0 : getMoveDirection.Invoke(Surrounding);
            //var inputX = Input.GetAxisRaw("Horizontal");
            if (Mathf.Abs(inputX) == 1f)
            {
                var rotationY = inputX > 0 ? 0 : 180;
                transform.rotation = Quaternion.Euler(0, rotationY, 0f);
                movePoint.position += new Vector3(inputX, 0f, 0f);
            }
        }

        

        UpdateAnimationState();
    }

    public void Stop()
    {
        animator.SetBool("running", false);
        this.enabled = false;
    }

    public void CheckSurrounding()
    {
        var currentPosition = CheckPosition(new Vector2(transform.position.x , transform.position.y));
        var right = CheckPosition(new Vector2(transform.position.x + 1.3f, transform.position.y));

        Surrounding = new PlayerSurrounding(null, null, right, null, null, null, null, null, currentPosition);
    }

    private IGameObject CheckPosition(Vector2 position)
    {
        var collider = Physics2D.OverlapCircle(position, .02f);
        if (collider is not null && collider.GetComponent<IInteractable>() is not null)
        {
            var interactable = collider.GetComponent<IInteractable>();
            return interactable.GameObject;
        }

        return null;
    }

    private void UpdateAnimationState()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            animator.SetBool("running", false);
        }
        else
        {
            animator.SetBool("running", true);
        }
    }
}
