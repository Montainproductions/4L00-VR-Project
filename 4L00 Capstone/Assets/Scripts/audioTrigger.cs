using UnityEngine;

public class audioTrigger : MonoBehaviour
{
    [SerializeField]
    public AudioSource AudioSource;
    private Vector3 position;
    
    // If the Player object enters the collider, spawn an audio source Instance then destroy the this object.
    void OnTriggerEnter(Collider other)
    {
        // Check to see if the object entering the collider has the 'Player' tag
        if(other.CompareTag("Player") == true)
        {
            // Save at current object position as a variable
            position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // Spawn Audio Source at GameObjects location
            Instantiate(AudioSource, position, Quaternion.identity);
            // Destroy this GameObject
            Destroy(gameObject);
        }
    }
}
