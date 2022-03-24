using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private GameObject _player;
    private static float _preparationTime = 2;
    private Transform _spawnpos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _spawnpos = gameObject.transform;
            StartCoroutine(DelayCoroutine(_spawnpos));

        }
    }

    IEnumerator DelayCoroutine(Transform spawnpos)
    {

        yield return new WaitForSeconds(_preparationTime);
        Debug.Log(spawnpos.position);
        Instantiate(_bombPrefab, _spawnpos.position, Quaternion.identity);

    }
}
