using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirectionScript : MonoBehaviour
{
    public static void ChangeDirection(List<Sprite> objSprites, GameObject target, FixedJoystick joystick)
    {

        if (joystick.Direction.y >= joystick.Direction.x && joystick.Direction.y >= -joystick.Direction.x && joystick.Direction.y != 0 && joystick.Direction.x != 0)
        {
            target.GetComponent<SpriteRenderer>().sprite = objSprites[2];
        }
        if (-joystick.Direction.y >= joystick.Direction.x && -joystick.Direction.y >= -joystick.Direction.x && joystick.Direction.y != 0 && joystick.Direction.x != 0)
        {
            target.GetComponent<SpriteRenderer>().sprite = objSprites[3];
        }
        if (joystick.Direction.x >= joystick.Direction.y && joystick.Direction.x >= -joystick.Direction.y && joystick.Direction.y != 0 && joystick.Direction.x != 0)
        {
            target.GetComponent<SpriteRenderer>().sprite = objSprites[0];
        }
        if (-joystick.Direction.x >= joystick.Direction.y && -joystick.Direction.x >= -joystick.Direction.y && joystick.Direction.y != 0 && joystick.Direction.x != 0)
        {
            target.GetComponent<SpriteRenderer>().sprite = objSprites[1];
        }

        //Explanation of conditional logic -> https://ibb.co/Zzgv2qX
        //Sorry for a large number of if, I hadn't come up with anything more optimized
    }
    public static void ChangeDirection(List<Sprite> objSprites, GameObject target ,Vector3 direction)
    {
        if (direction.y >= direction.x && direction.y >= -direction.x && direction.y != 0 && direction.x != 0)
        {
            target.GetComponent<SpriteRenderer>().sprite = objSprites[2];
        }
        if (-direction.y >= direction.x && -direction.y >= -direction.x && direction.y != 0 && direction.x != 0)
        {
            target.GetComponent<SpriteRenderer>().sprite = objSprites[3];
        }
        if (direction.x >= direction.y && direction.x >= -direction.y && direction.y != 0 && direction.x != 0)
        {
            target.GetComponent<SpriteRenderer>().sprite = objSprites[0];
        }
        if (-direction.x >= direction.y && -direction.x >= -direction.y && direction.y != 0 && direction.x != 0)
        {
            target.GetComponent<SpriteRenderer>().sprite = objSprites[1];
        }
    }
}
