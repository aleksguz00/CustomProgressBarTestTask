using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _minDistance = -20f;
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private float _playerDistanceZ = 50;
    
    private float _startX;
    private float _startZ;
    private float _nextX;
    private float _nextZ;
    private float _chance; // Interval 0 - 1
    private float _currentPlayerSpeed;
    private float _nextPlayerSpeed;
    private float _maxPlayerSpeed;
    private float _apperancePeriod;
    private bool _isCreating = false;
    private Transform _player;
    private Vector3 _firstPosition;

    private void Start()
    {       
        _player = PlayerMovement.Instance.transform;
        _currentPlayerSpeed = PlayerMovement.Instance.ForwardSpeed;
        _nextPlayerSpeed = _currentPlayerSpeed + 5f;
        _chance = 0.5f;
        _apperancePeriod = 1f;

        _startX = _player.position.x + Random.Range(_minDistance, _maxDistance);
        _startZ = _player.position.z + Random.Range(0, _maxDistance);

        _firstPosition = new Vector3(_startX, 0, _startZ);

        GameInput.Instance.OnSideMoveEvent.AddListener(OnInputEventCallback);
    }

    private void Update()
    {
        if (_isCreating == false && LevelStarter.isStarted == true)
        {            
            _isCreating = true;
            StartCoroutine(GenerateObstacle());
        }
    }

    private void LateUpdate()
    {
        _playerDistanceZ = 50f;
        UpdateChance();
    }

    private void UpdateChance()
    {
        _currentPlayerSpeed = PlayerMovement.Instance.ForwardSpeed;

        if (_currentPlayerSpeed >= _nextPlayerSpeed  && _currentPlayerSpeed < _maxPlayerSpeed)
        {
            _nextPlayerSpeed += 5f;
            _chance += 0.1f;
            _apperancePeriod -= 0.1f;

            if (_chance > 1f)
            {
                _chance = 1f;
            }

            if (_apperancePeriod < 0.5f)
            {
                _apperancePeriod = 0.5f;
            }
        }
    }

    private void OnInputEventCallback()
    {
        _playerDistanceZ = 5f;
    }

    private IEnumerator GenerateObstacle()
    {
        _nextX = _player.position.x + Random.Range(_minDistance, _maxDistance);

        _nextZ = _player.position.z + _playerDistanceZ;

        Vector3 nextPosition = _firstPosition + new Vector3(_nextX, 0, _nextZ);

        GameObject obstaclePrefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];

        obstaclePrefab.tag = "Obstacle"; 
        
        if (Random.Range(0f, 1f) <= _chance)
        {
            Instantiate(obstaclePrefab, nextPosition, Quaternion.identity);
        }

        yield return new WaitForSeconds(0.1f * _apperancePeriod);

        _isCreating = false;
    }
}

