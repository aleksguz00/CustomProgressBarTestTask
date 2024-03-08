using System.Collections;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private float _fadeInTime = 1.5f;
    [SerializeField] private GameObject _countDownThree;
    [SerializeField] private GameObject _countDownTwo;
    [SerializeField] private GameObject _countDownOne;
    [SerializeField] private GameObject _countDownGo;
    [SerializeField] private GameObject _countDownFadeIn;
    [SerializeField] private AudioSource _readyFx;
    [SerializeField] private AudioSource _goFX;

    public static bool isStarted = false;

    private void Start()
    {
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(_fadeInTime);

        _countDownThree.SetActive(true);
        _readyFx.Play();
        yield return new WaitForSeconds(1f);

        _countDownTwo.SetActive(true);
        _readyFx.Play();
        yield return new WaitForSeconds(1f);

        _countDownOne.SetActive(true);
        _readyFx.Play();
        yield return new WaitForSeconds(1f);

        isStarted = true;
        _countDownGo.SetActive(true);
        _goFX.Play();
    }
}
