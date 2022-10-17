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
    
    
    // If the Player object enters the collider, spawn an audio source Instance then destroy the this object.
    void OnTriggerEnter(Collider other)
    {
        if(playerCollideOnly == true)
        {
            // Check to see if the object entering the collider has the 'Player' tag
            if (other.CompareTag("Player") == true)
            {
                AudioTrigger();
            }
        }
        else
        {
            AudioTrigger();
        }
        
        
    }
    private void AudioTrigger()
    {
        // Save at current object position as a variable
        position = new Vector3(GameObject.transform.position.x, GameObject.transform.position.y, GameObject.transform.position.z);
        // Spawn Audio Source at GameObjects location

        if (followObject == true)
        {
            // Spawns an Audio Source as a Child of this GameObject
            Instantiate(AudioSource, position, Quaternion.identity, GameObject.transform);
        }
        else
        {
            // Spawns the audiosource at the GameObjects Location
            Instantiate(AudioSource, position, Quaternion.identity);
        }

        if (destroyTheObject == true)
        {
            // Destroy this GameObject
            Destroy(GameObject);
        }
        if (triggerOnlyOnce == true)
        {
            // Remove's this script from the pin
            Destroy(this);
        }
    }
}
