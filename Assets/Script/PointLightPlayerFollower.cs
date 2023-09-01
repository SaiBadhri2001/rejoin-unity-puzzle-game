using UnityEngine;

public class PointLightPlayerFollower : MonoBehaviour
{
    public GameObject _player;
    public float PointLightHeight;
    void Update()
    {
        transform.position = _player.transform.position + new Vector3(0, PointLightHeight, 0);
    }
}
