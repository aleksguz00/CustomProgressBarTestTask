using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private const string ANIMATION_NAME = "Stumble Backwards";

    [SerializeField] GameObject _player;
    [SerializeField] GameObject _charModel;
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _levelControl;
    [SerializeField] GameObject _progressBar;
    [SerializeField] AudioSource _hitFx;

    private void OnTriggerEnter(Collider other)
    {
        RegisterOverlap();
    }
    
    private void RegisterOverlap()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        _player.GetComponent<PlayerMovement>().enabled = false;
        _charModel.GetComponent<Animator>().Play(ANIMATION_NAME);
        _progressBar.SetActive(false);
        _levelControl.GetComponent<LevelDistance>().enabled = false;
        _hitFx.Play();
        _mainCamera.GetComponent<Animator>().enabled = true;
        _levelControl.GetComponent<EndRunSequence>().enabled = true;
        LevelStarter.isStarted = false;
    }
}
