using UnityEngine;
public class CompleteLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LevelManager.Instance.LoadNextLevel();
        }
    }
}
