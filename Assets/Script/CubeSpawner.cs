using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject CubePrefab;
    [SerializeField] private Transform RejoinPlayer;
    [SerializeField] private GameObject _cubeParent;
    [HideInInspector]
    public List<GameObject> _spawnedCubes;
    public static CubeSpawner Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    public void SpawnACube()
    {
        if (!LevelManager.Instance._isNativeLevel)
        {
            GameObject _spawnedCube = Instantiate(CubePrefab, RejoinPlayer.position, Quaternion.identity);
            _spawnedCube.transform.parent = _cubeParent.transform;
            _spawnedCubes.Add(_spawnedCube);
            _spawnedCube.SetActive(false);
        }
    }
    public void DisplayAllSpawnedCubes()
    {
        foreach (GameObject _spawnedCube in _spawnedCubes)
        {
            _spawnedCube.SetActive(true);
        }
    }
    public void HideAllSpawnedCubes()
    {
        foreach (GameObject _spawnedCube in _spawnedCubes)
        {
            _spawnedCube.SetActive(false);
        }
    }
}
