using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private Button _spawnButton;
    private Vector3 _spawnpos;

    private static readonly float _disableButtonTime = 2;
    private static readonly float _preparationTime = 1;

    public void SpawnBomb()
    {
        StartCoroutine(DelayCoroutine());
        StartCoroutine(DisableButtonCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        _spawnpos = gameObject.transform.position;
        yield return new WaitForSeconds(_preparationTime);
        Instantiate(_bombPrefab, _spawnpos, Quaternion.identity);

    }

    private IEnumerator DisableButtonCoroutine()
    {
        _spawnButton.interactable = false;
        yield return new WaitForSeconds(_disableButtonTime);
        _spawnButton.interactable = true;
    }
}
