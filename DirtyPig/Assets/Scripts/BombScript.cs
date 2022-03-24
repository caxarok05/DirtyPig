using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    
    [SerializeField] private Sprite _dirtyPigSprite;
    [SerializeField] private GameObject _deathPanel;

    private void Start()
    {
        _deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoExplosion(collision);
        Debug.Log(1);
    }
    private void DoExplosion(Collider2D collision)
    {
        GameObject explosionVictim = collision.gameObject;
        if (explosionVictim.tag == "PlayerTag")
        {
            Time.timeScale = 0;
            _deathPanel.SetActive(true);

        }
        if (explosionVictim.tag == "FarmerTag")
        {
            explosionVictim.GetComponent<SpriteRenderer>().sprite = _dirtyPigSprite;
        }
        if (explosionVictim.tag == "DogTag")
        {
            explosionVictim.GetComponent<SpriteRenderer>().sprite = _dirtyPigSprite;
        }

    }


}
