using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] private List<Collectable> CollectablesInLevel;
    public static int TotalCollectables;
    private int _coinsCollected = 0;
    [HideInInspector]
    public bool _isNativeLevel = true;
    [Header("Reference Equals")]
    [SerializeField] private GameObject _nativeGameObject;
    [SerializeField] private GameObject _rejoinGameObject;
    [Header("Next Level Name")]
    [SerializeField] private string _nextLevelName;

    public static LevelManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    void Start()
    {
        TotalCollectables = CollectablesInLevel.Count;

        _nativeGameObject.SetActive(true);
        _rejoinGameObject.SetActive(false);

        _isNativeLevel = true;

        _coinsCollected = 0;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadRelativeGameObjects()
    {
        if (_isNativeLevel)
        {
            _nativeGameObject.SetActive(false);
            _rejoinGameObject.SetActive(true);

            _isNativeLevel = false;

            if (CubeSpawner.Instance._spawnedCubes.Count > 0)
            {
                CubeSpawner.Instance.HideAllSpawnedCubes();
            }
        }
        else
        {
            _nativeGameObject.SetActive(true);
            _rejoinGameObject.SetActive(false);

            _isNativeLevel = true;

            if (CubeSpawner.Instance._spawnedCubes.Count > 0)
            {
                CubeSpawner.Instance.DisplayAllSpawnedCubes();
            }
        }
    }

    public void PickedCoin()
    {
        _coinsCollected += 1;
    }
    public void LoadNextLevel()
    {
        if (_isNativeLevel && _coinsCollected == TotalCollectables)
        {
            SceneManager.LoadScene(_nextLevelName);
        }
    }
}
