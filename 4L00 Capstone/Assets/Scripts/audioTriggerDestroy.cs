using UnityEngine;

public class audioTriggerDestroy : MonoBehaviour
{
    [SerializeField]
    public AudioSource AudioSource;
    private Vector3 position;

    // If the Player object enters the collider, spawn an audio source Instance as a child of this object
    void OnTriggerEnter(Collider other)
    {
        // Check to see if the object entering the collider has the 'Player' tag
        if (other.CompareTag("Player") == true)
        {
            // Save at current object position as a variable
            position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // Spawns an Audio Source as a Child of this GameObject
            Instantiate(AudioSource, position, Quaternion.identity, gameObject.transform);
            // Remove's this script from the pin
            Destroy(this);
        }
    }
}
