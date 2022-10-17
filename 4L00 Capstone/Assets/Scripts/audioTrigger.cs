using UnityEngine;

public class audioTrigger : MonoBehaviour
{
    [SerializeField]
    public AudioSource AudioSource;
    [SerializeField]
    private GameObject GameObject;
    private Vector3 position;

    public bool playerCollideOnly;
    public bool followObject;
    public bool triggerOnlyOnce;
    public bool destroyTheObject;


    // If the Player object enters the collider, spawn an audio source in accordance to the parameters set
    void OnTriggerEnter(Collider other)
    {
        // Check whether the sound can only be triggered by the Player
        if (playerCollideOnly == true)
        {
            // Check to see if the object entering the collider has the 'Player' tag
            if (other.CompareTag("Player") == true)
            {
                AudioTrigger();
            }
        }
        else
        {
            // Spawn Audio when anything interacts with this collider
            AudioTrigger();
        }
        
        
    }

    // Spawn the Audio
    private void AudioTrigger()
    {
        // Save at current object position as a variable
        position = new Vector3(GameObject.transform.position.x, GameObject.transform.position.y, GameObject.transform.position.z);
        
        // Check if we want the Audio to follow the object through it's movement
        if (followObject == true)
        {
            // Spawns an Audio Source as a Child of this GameObject
            Instantiate(AudioSource, position, Quaternion.identity, GameObject.transform);
        }
        else
        {
            // Spawn Audio Source at GameObjects location
            Instantiate(AudioSource, position, Quaternion.identity);
        }

        // Incase you want to destroy the object after spawning the sound source
        if (destroyTheObject == true)
        {
            // Destroy this GameObject
            Destroy(GameObject);
        }
        // Removes Script from the object to prevent the script from being called again
        // Use only if you want to keep the object around after triggering the Audio
        if (triggerOnlyOnce == true)
        {
            // Remove's this script from the pin
            Destroy(this);
        }
    }
}
