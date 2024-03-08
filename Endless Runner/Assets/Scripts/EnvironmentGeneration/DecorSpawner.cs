using System.Collections;
using UnityEngine;

public class DecorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _decorPrefabs;
    [SerializeField] private float _minDistance = -20f;
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private float _playerDistanceZ = 50;

    private float _startX;
    private float _startZ;
    private float _nextX;
    private float _nextZ;

    private bool _isCreating = false;
    private Transform _player;
    private Vector3 _firstPosition;

    private void Start()
    {
        _player = PlayerMovement.Instance.transform;

        _startX = _player.position.x + Random.Range(_minDistance, _maxDistance);
        _startZ = _player.position.z + Random.Range(0, _maxDistance);

        _firstPosition = new Vector3(_startX, 0, _startZ);
    }

    private void Update()
    {
        if (_isCreating == false && LevelStarter.isStarted == true)
        {
            _isCreating = true;
            StartCoroutine(GenerateDecor());
        }
    }

    private IEnumerator GenerateDecor()
    {
        _nextX = _player.position.x + Random.Range(_minDistance, _maxDistance);

        _nextZ = _player.position.z + _playerDistanceZ;

        Vector3 nextPosition = _firstPosition + new Vector3(_nextX, 0, _nextZ);

        GameObject obstaclePrefab = _decorPrefabs[Random.Range(0, _decorPrefabs.Length)];     

        Instantiate(obstaclePrefab, nextPosition, Quaternion.identity);

        yield return new WaitForSeconds(0.1f);

        _isCreating = false;
    }
}
