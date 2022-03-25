using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private List<Sprite> _dogSprites;
    [SerializeField] private List<Sprite> _angryDogSprites;
    [SerializeField] private List<Sprite> _dirtyDogSprites;
    private List<Sprite> _currentDogSprite;

    [SerializeField] private AgentScript _dogAgent;

    private Vector3 _movementDirection;
    private Vector3 _currentPosition;
    private Vector3 _previousPosition;

    private bool IsDogAngry;
    private bool IsDogDirty;

    private void CalmDog()
    {
        _currentDogSprite = _dogSprites;
    }

    private void MakeDogAngry()
    {
        _currentDogSprite = _angryDogSprites;
    }

    private void PolluteDog()
    {
        Debug.Log("DogPollute");
        _currentDogSprite = _dirtyDogSprites;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<AgentScript>().enabled = false;
        StartCoroutine(RemoveDirt());
        BombScript.IsDogBlownUp = false;
        IsDogDirty = false;
    }

    private IEnumerator RemoveDirt()
    {
        yield return new WaitForSeconds(3);
        CalmDog();
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<AgentScript>().enabled = true;
        
    }

    private void FixedUpdate()
    {
        IsDogAngry = _dogAgent.IsAngry;
        IsDogDirty = BombScript.IsDogBlownUp;
        if (IsDogAngry == false)
        {
            CalmDog();
        }
        if (IsDogAngry == true)
        {
            MakeDogAngry();
        }
        if (IsDogDirty == true)
        {
            Debug.Log("DogDirty");
            PolluteDog();
        }

        _previousPosition = _currentPosition;
        _currentPosition = gameObject.transform.position;
        _movementDirection = new Vector3(_currentPosition.x - _previousPosition.x, _currentPosition.y - _previousPosition.y);
        ChangeDirectionScript.ChangeDirection(_currentDogSprite, gameObject, _movementDirection);
    }
}
