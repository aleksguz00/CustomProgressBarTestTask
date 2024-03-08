using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    [SerializeField] private GameObject _distanceStartDisplay;
    [SerializeField] private GameObject _distanceEndDisplay;
    [SerializeField] private Image _mask;

    private int _distanceRun;
    private bool _isAddingDistance = false;
    private float _distanceDelay = 0.35f;
    private float _playerSpeed;
    private float _speedInterval = 5f;
    private int _distanceInterval = 100;

    private float _maxSpeed = 50f;
    private float _nextDistance;

    private float _currentFill;

    private void Start()
    {
        _distanceRun = 0;
        _playerSpeed = PlayerMovement.Instance.ForwardSpeed;
        _nextDistance = _distanceRun + _distanceInterval;
    }

    private void FixedUpdate()
    {
        CountDistance();
        UpdatePlayerSpeed();
        UpdateFill();
    }

    private void UpdatePlayerSpeed()
    {
        _playerSpeed = PlayerMovement.Instance.ForwardSpeed;        
    }

    private void CountDistance()
    {
        if (_isAddingDistance == false && LevelStarter.isStarted == true)
        {
            _isAddingDistance = true;

            StartCoroutine(AddingDistance());
        }
    }

    private void UpdateFill()
    {
        _currentFill = _distanceRun;

        float fillAmount = (_currentFill % _distanceInterval) / (float)_distanceInterval;
        _mask.fillAmount = fillAmount;
    }

    IEnumerator AddingDistance()
    {
        if (_distanceRun >= _nextDistance && _playerSpeed < _maxSpeed)
        {
            PlayerMovement.Instance.ForwardSpeed += _speedInterval;
            _nextDistance += _distanceInterval;
        }       

        _distanceRun += Mathf.RoundToInt(_playerSpeed / 10);      
        _distanceStartDisplay.GetComponent<Text>().text = "" + _distanceRun;
        _distanceEndDisplay.GetComponent<Text>().text = "" + _distanceRun;

        yield return new WaitForSeconds(_distanceDelay);
        _isAddingDistance = false;
    }
}
