using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private ActionObject obj;
    private ActDialogue obj1;

    private Vector2 _movement;

    private Rigidbody2D _rb;
    private Animator _animator;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!inDialogue())
        {
            _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

            _rb.velocity = _movement * _moveSpeed;

            if (_movement != Vector2.zero)
            {
                _animator.SetFloat(_horizontal, _movement.x);
                _animator.SetFloat(_vertical, _movement.y);

                _animator.SetFloat(_lastHorizontal, _movement.x);
                _animator.SetFloat(_lastVertical, _movement.y);
            } else
            {
                _animator.SetFloat(_horizontal, 0);
                _animator.SetFloat(_vertical, 0);
            }
        }
        else
        {
            _rb.velocity = Vector2.zero;
            _animator.SetFloat(_horizontal, 0);
            _animator.SetFloat(_vertical, 0);
        }
    }

    private bool inDialogue()
    {
        return DialogueSystem.DialogueHolder.IsDialogueActive;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ActObj")
        {
            obj = collision.gameObject.GetComponent<ActionObject>();
            obj1 = collision.gameObject.GetComponent<ActDialogue>();

            if (Input.GetKey(KeyCode.Return))
            {
                if (obj != null)
                {
                    obj.ActivateDialogue();
                }
                
                if (obj1 != null)
                {
                    obj1.ActiveDialogue();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        obj = null;
    }
}
