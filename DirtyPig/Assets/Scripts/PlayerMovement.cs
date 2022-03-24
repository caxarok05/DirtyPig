using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _acceleration;
    private Vector3 _movementDirection;
    [SerializeField] private List<Sprite> _pigSprites;
    [SerializeField] private Sprite _pigbasicSprite;


    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _pigbasicSprite;
        _rb = GetComponent<Rigidbody2D>();
        //_pigCurrentSprite = GetComponent<SpriteRenderer>();
        
    }

    private void FixedUpdate()
    {
        ChangeDirection();
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        _movementDirection = transform.up * verticalMovement + transform.right * horizontalMovement;
        
        transform.Translate(_movementDirection * _acceleration);
    }

    private void ChangeDirection()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().sprite = _pigSprites[0];
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().sprite = _pigSprites[1];
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            GetComponent<SpriteRenderer>().sprite = _pigSprites[2];
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            GetComponent<SpriteRenderer>().sprite = _pigSprites[3];
        }

    }

}
