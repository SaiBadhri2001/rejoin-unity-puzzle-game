using UnityEngine;
using UnityEngine.VFX;

public class Collectable : MonoBehaviour
{
    public GameObject Coin;
    public Vector3 PitchYawRotation;
    public VisualEffect VFX;
    void Start()
    {
        VFX.Stop();
    }
    void Update()
    {
        transform.Rotate(PitchYawRotation * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LevelManager.Instance.PickedCoin();
            Destroy(Coin);
            VFX.Play();
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
