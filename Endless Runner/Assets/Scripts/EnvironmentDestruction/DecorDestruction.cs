using UnityEngine;

public class DecorDestruction : MonoBehaviour
{
    private const string PARENT_NAME = "Decor(Clone)";

    [SerializeField] private float _destroyDistance;

    private string _parentName;

    private void Update()
    {
        _parentName = transform.name;

        if (LevelStarter.isStarted)
        {
            DestroyObstacle();
        }        
    }

    private void DestroyObstacle()
    {
        if (transform.position.z < PlayerMovement.Instance.transform.position.z - _destroyDistance)
        {
            if (_parentName == PARENT_NAME)
            {
                Destroy(gameObject);
            }
        }
    }
}
