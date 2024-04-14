using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _player;
    [SerializeField]
    private float _patrolSpeed;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _chaseRange;
    [SerializeField]
    private Transform _pointA;
    [SerializeField]
    private Transform _pointB;
    private Rigidbody2D _rigidbody;
    private bool _isAttacking;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        ChangeStatePatrol();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        if(_isAttacking == true)
        {
            if(distanceToPlayer > _chaseRange)
            {
                ChangeStatePatrol();
            }
            else
            {
                Attack();
            }
        }
        else
        {
            if(distanceToPlayer < _attackRange)
            {
                ChangeStateAttack();
            }
            else
            {
                Patrol();
            }
        }
        if(_rigidbody.velocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }
    private void ChangeStatePatrol()
    {
        _isAttacking = false;
        Patrol();
    }
    private void ChangeStateAttack()
    {
        _isAttacking = true;
        Attack();
    }
    private void Attack()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rigidbody.velocity = new Vector2(direction.x * _patrolSpeed, _rigidbody.velocity.y);
        if(Vector2.Distance(transform.position, _player.position) > 10)
        {
            ChangeStatePatrol();
        }
    }
    private void Patrol()
    {
        Vector2 direction = (_pointB.position - transform.position).normalized;
        _rigidbody.velocity = new Vector2(direction.x * _patrolSpeed, _rigidbody.velocity.y);
        if(Vector2.Distance(transform.position, _pointB.position) < 1)
        {
            Transform temp = _pointB;
            _pointB = _pointA;
            _pointA = temp;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.Die();
        }
    }
}
