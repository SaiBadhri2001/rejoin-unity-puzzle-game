using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private NativePlayerMovement _nativePlayerMovement;
    [SerializeField] private RejoinPlayerMovement _rejoinPlayerMovement;
    [Header("Key Reference")]
    [SerializeField] private KeyCode _keyToRejoin = KeyCode.E;
    [SerializeField] private KeyCode _keyToRestart = KeyCode.R;
    [SerializeField] private KeyCode _keyToSpawnCube = KeyCode.P;
    public static PlayerInputManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(_keyToRejoin))
        {
            LevelManager.Instance.LoadRelativeGameObjects();
        }
        if (Input.GetKeyDown(_keyToRestart))
        {
            LevelManager.Instance.RestartLevel();
        }
        if (Input.GetKeyDown(_keyToSpawnCube))
        {
            CubeSpawner.Instance.SpawnACube();
        }
        if (_nativePlayerMovement.transform.position.y <= -10 || _rejoinPlayerMovement.transform.position.y <= -10)
        {
            LevelManager.Instance.RestartLevel();
        }

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (LevelManager.Instance._isNativeLevel)
        {
            _nativePlayerMovement.MovePlayer();
        }
        else
        {
            _rejoinPlayerMovement.MovePlayer();
        }
    }
}
