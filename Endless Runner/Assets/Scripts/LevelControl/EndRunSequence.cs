using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    [SerializeField] private GameObject _aliveDistance;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _fadeOut;

    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(1.5f);
        _aliveDistance.SetActive(false);
        _endScreen.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        _fadeOut.SetActive(true);

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
