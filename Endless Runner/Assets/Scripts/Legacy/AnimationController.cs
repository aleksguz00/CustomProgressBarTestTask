using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject _charModel;
    [SerializeField] private Animation[] _anims;

    private enum Anim
    {
        RUN,
        FALL,
        IDLE,
        CAMERA
    }

    public static AnimationController Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public void PlayRun()
    {
        _charModel.GetComponent<Animator>().Play(_anims[(int)Anim.RUN].name);
    }

    public void PlayFall()
    {
        _charModel.GetComponent<Animator>().Play(_anims[(int)Anim.FALL].name);
    }

    public void PlayIdle()
    {
        _charModel.GetComponent<Animator>().Play(_anims[(int)Anim.IDLE].name);
    }

    //public void CameraShake()
    //{
    //    _animations[(int)Anim.CAMERA].Play();
    //}
}
