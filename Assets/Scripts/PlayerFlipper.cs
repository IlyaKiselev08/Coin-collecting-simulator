using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipper : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if(_playerMovement.isDie == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _spriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}
