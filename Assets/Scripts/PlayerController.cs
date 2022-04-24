using Assets.Scripts.Interfaces;
using ClientFramework;
using ClientFramework.Interaction;
using GameUtilitys.Utilities;
using GameUtilitys.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float _stayTime = 0.75f;
    public float _workingTime = 1.5f;
    public Transform movePoint;
    public Animator animator;

    [HideInInspector]
    public Func<ISurrounding, IPlayerAction> getNextAction;

    [HideInInspector]
    public ISurrounding Surrounding { get; private set; } = new PlayerSurrounding();

    private bool _isbusy;
    private bool _isWorking;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePoint.position = new Vector3(movePoint.position.x, transform.position.y, movePoint.position.z);
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (!_isbusy && Vector3.Distance(transform.position, movePoint.position) <= 0.2f)
        {
            CheckSurrounding();
            var nextAction = getNextAction is null ? Movement.Stay : getNextAction.Invoke(Surrounding);

            switch (nextAction)
            {
                case Movement move when  move == Movement.Stay:
                    PlayerMove(move);
                    StartCoroutine(Staying());
                    break;
                case Movement move:
                    PlayerMove(move);
                    break;
                case Installation install:
                    Installation(install);
                    StartCoroutine(Working());
                    break;
                default:
                    PlayerMove(Movement.Stay);
                    break;
            }
        }



        UpdateAnimationState();
    }

    IEnumerator Staying()
    {
        _isbusy = true;
        yield return new WaitForSeconds(_stayTime);
        _isbusy = false;
    }

    IEnumerator Working()
    {
        _isbusy = _isWorking = true;
        yield return new WaitForSeconds(_workingTime);
        _isbusy = _isWorking = false;
    }

    private void PlayerMove(Movement nextMove)
    {
        var rotationY = nextMove.XDirection switch
        {
            < 0 => 180,
            > 0 => 0,
            _ => transform.rotation.eulerAngles.y
        };
        transform.rotation = Quaternion.Euler(0, rotationY, 0f);
        movePoint.position += new Vector3(nextMove.XDirection, 0f, 0f);
    }

    private void Installation(Installation installation)
    {
        if (installation.Target is GameAsset asset && (asset == Surrounding.Right || asset == Surrounding.Left))
        {
            asset.Station = installation.Station;
        }
        else
        {
            Debug.LogWarning("Can't see the target station for installation");
        }
    }

    public void Stop()
    {
        animator.SetBool("running", false);
        animator.SetBool("doing", false);
        this.enabled = false;
    }

    public void CheckSurrounding()
    {
        var currentPosition = CheckPosition(transform.position, new Vector2(0, 0));
        var right = CheckPosition(transform.position, new Vector2(1.3f, 0));
        var left = CheckPosition(transform.position, new Vector2(-1.3f, 0));


        Surrounding = new PlayerSurrounding(null, null, right, null, null, null, left, null, currentPosition);
    }

    private IGameObject CheckPosition(Vector3 position, Vector2 offset)
    {
        var colliders = Physics2D.OverlapCircleAll(new Vector2(position.x + offset.x, position.y + offset.y), .02f);
        foreach (var collider in colliders)
        {
            if (collider is not null && collider.GetComponent<IInteractable>() is not null)
            {
                var interactable = collider.GetComponent<IInteractable>();
                return interactable.GameObject;
            }
        }

        return null;
    }

    private void UpdateAnimationState()
    {
        if (_isWorking && Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            animator.SetBool("running", false);
            animator.SetBool("doing", true);
        }
        else if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            animator.SetBool("running", false);
            animator.SetBool("doing", false);
        }
        else
        {
            animator.SetBool("doing", false);
            animator.SetBool("running", true);
        }
    }
}
