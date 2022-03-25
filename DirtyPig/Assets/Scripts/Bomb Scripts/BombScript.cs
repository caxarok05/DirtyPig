using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public static bool IsPlayerBlownUp = false;
    public static bool IsFarmerBlownUp = false;
    public static bool IsDogBlownUp = false;

    private void DoExplosion(Collider2D collision)
    {
        GameObject explosionVictim = collision.gameObject;
        if (explosionVictim.tag == "PlayerTag")
        {
            IsPlayerBlownUp = true;
        }
        if (explosionVictim.tag == "FarmerTag")
        {
            IsFarmerBlownUp = true;
            ScoreScript.Instance.Score++;
        }
    
        if (explosionVictim.tag == "DogTag")
        {
            IsDogBlownUp = true;
            ScoreScript.Instance.Score++;
        }
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoExplosion(collision);
    }
}
