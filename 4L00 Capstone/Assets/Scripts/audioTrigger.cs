using UnityEngine;

public class audioTrigger : MonoBehaviour
{
    [SerializeField]
    public AudioSource AudioSource;
    private Vector3 position;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == true)
        {
            position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(AudioSource, position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
