using UnityEngine;

public class TerrainDestoyer : MonoBehaviour
{
    private const string PARENT_NAME = "Platform(Clone)";

    private string _parentName;
    private float _destroyDistance;

    private void Start()
    {
        _destroyDistance = transform.localScale.z;
    }

    private void Update()
    {
        _parentName = transform.name;

        if (LevelStarter.isStarted == true)
        {
            DestroyPlatform();
        }      
    }

    private void DestroyPlatform()
    {
        if (transform.position.z < PlayerMovement.Instance.transform.position.z - _destroyDistance)
        {
            if (_parentName == PARENT_NAME)
                Destroy(gameObject);
        }
    }
}
