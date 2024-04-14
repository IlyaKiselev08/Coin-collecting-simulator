using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rb;
    [SerializeField]
    private float _jumpForce;
    private PlayerAnimator _playerAnimator;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private float rayGroundDistance;
    [SerializeField]
    private float raySideDistance;
    public bool isDie;
    [SerializeField]
    private GameManager _gameManager;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDie == false)
        {
            if (_gameManager.isGameOver == true)
            {
                return;
            }
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput < 0 && OnLeftSide() == true)
            {
                horizontalInput = 0;
            }
            if (horizontalInput > 0 && OnRightSide() == true)
            {
                horizontalInput = 0;
            }
            _rb.velocity = new Vector2(horizontalInput * speed, _rb.velocity.y);
            if (Input.GetKey(KeyCode.Space) && OnGround() == true)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                _playerAnimator.Jump();
            }
        }
    }
    public bool OnGround()
    {
        bool isGround = Physics2D.Raycast(transform.position, Vector2.down, rayGroundDistance, _groundLayer);
        return isGround;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - rayGroundDistance));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x - raySideDistance, transform.position.y));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x - raySideDistance, transform.position.y));
    }
    private bool OnLeftSide()
    {
        bool isLeftSideUp = Physics2D.Raycast(transform.position, Vector2.left, raySideDistance, _groundLayer);
        bool isLeftSideDown = Physics2D.Raycast(transform.position, Vector2.left, raySideDistance, _groundLayer);
        if(isLeftSideUp == true &&  isLeftSideDown == true)
        {
            return true;
        }
        return false;
    }
    private bool OnRightSide()
    {
        bool isRightSideUp = Physics2D.Raycast(transform.position, Vector2.right, raySideDistance, _groundLayer);
        bool isRightSideDown = Physics2D.Raycast(transform.position, Vector2.right, raySideDistance, _groundLayer);
        if(isRightSideUp == true && isRightSideDown == true)
        {
            return true;
        }
        return false;
    }
    public void Die()
    {
        if(isDie == false)
        {
            _playerAnimator.Die();
            isDie = true;
            _gameManager.GameOver();
        }
    }
}
