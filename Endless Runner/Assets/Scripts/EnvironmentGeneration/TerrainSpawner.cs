using System.Collections;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _terrainPrefab;
    [SerializeField] private float _zPosition;

    private bool _isCreating = false;
    private Transform _player;

    private void Start()
    {
        _zPosition = _terrainPrefab.transform.localScale.z;
        _player = PlayerMovement.Instance.transform;
    }

    private void Update()
    {
        if (_isCreating == false)
        {
            _isCreating = true;
            StartCoroutine(GenerateTerrain());
        }
    }

    IEnumerator GenerateTerrain()
    {      

        GameObject clone = Instantiate(_terrainPrefab, new Vector3(0, 0, _zPosition), Quaternion.identity);
        clone.tag = "PlatformClone";

        _zPosition += _terrainPrefab.transform.localScale.z;

        yield return new WaitForSeconds(0.2f);

        _isCreating = false;
    }
}
