using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FarmerController : MonoBehaviour
{
    [Header("Sprites")]

    [SerializeField] private List<Sprite> _farmerSprites;
    [SerializeField] private List<Sprite> _angryFarmerSprites;
    [SerializeField] private List<Sprite> _dirtyFarmerSprites;
    private List<Sprite> _currentFarmerSprite;

    [SerializeField] private AgentScript _farmerAgent;

    private Vector3 _currentPosition;
    private Vector3 _previousPosition;
    private Vector3 _movementDirection;

    private bool IsFarmerAngry;
    private bool IsFarmerDirty;


    private void CalmFarmer()
    {
        _currentFarmerSprite = _farmerSprites;
    }

    private void MakeFarmerAngry()
    {
        _currentFarmerSprite = _angryFarmerSprites;
    }

    private void PolluteFarmer()
    {
        _currentFarmerSprite = _dirtyFarmerSprites;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<AgentScript>().enabled = false;
        StartCoroutine(RemoveDirt());
    }

    IEnumerator RemoveDirt()
    {
        yield return new WaitForSeconds(3);
        CalmFarmer();
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<AgentScript>().enabled = true;
        BombScript.IsFarmerBlownUp = false;
    }

    private void FixedUpdate()
    {
        IsFarmerAngry = _farmerAgent.IsAngry;
        IsFarmerDirty = BombScript.IsFarmerBlownUp;
        if (IsFarmerAngry == false)
        {
            CalmFarmer();
        }
        if (IsFarmerAngry == true)
        {
            MakeFarmerAngry();
        }
        if (IsFarmerDirty == true)
        {
            PolluteFarmer();
        }


        _previousPosition = _currentPosition;
        _currentPosition = gameObject.transform.position;
        _movementDirection = new Vector3(_currentPosition.x - _previousPosition.x, _currentPosition.y - _previousPosition.y);
        ChangeDirectionScript.ChangeDirection(_currentFarmerSprite, gameObject, _movementDirection);
    }
}
