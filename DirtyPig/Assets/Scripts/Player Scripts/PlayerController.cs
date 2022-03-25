using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public static bool IsPlayer—aught = false;

    [SerializeField] private List<Sprite> _pigSprites;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _acceleration;
    private Vector3 _movementDirection;
    
    private void FixedUpdate()
    {
        ChangeDirectionScript.ChangeDirection(_pigSprites, gameObject, _joystick);
        _movementDirection = transform.up * _joystick.Vertical + transform.right * _joystick.Horizontal;

        transform.Translate(_movementDirection * _acceleration);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FarmerTag" || collision.gameObject.tag == "DogTag")
        {
            IsPlayer—aught = true;
        }
    }



}
