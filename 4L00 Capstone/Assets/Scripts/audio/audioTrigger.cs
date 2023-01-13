using UnityEngine;
using UnityEngine.Audio;

public class audioTrigger : MonoBehaviour
{
    [Header("Spawn Audio Source")]
    [SerializeField]
    private bool spawnAudioSource = false;
    [SerializeField]
    public AudioSource audioSource;
    [SerializeField]
    private GameObject gameObject;
    private Vector3 position;
    private Sc_AudioManager audioManager;
    //[SerializeField]
    //private AudioClip audioClip;
    [SerializeField]
    private bool playerCollideOnly, followObject, destroyTheObject, triggerOnlyOnce;

    private void Start()
    {
        //TryGetComponent(out Sc_AudioManager audiomanager);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Sc_AudioManager>();
    }
    // If the Player object enters the collider, spawn an audio source in accordance to the parameters set
    void OnTriggerExit(Collider other)
    {
        /*// Check to see if the object entering the collider has the 'Player' tag
        if (other.CompareTag("Player") == true)
        {
            if (changeAudioMixerVolume)
            {
                ChangeAudioMixer();
            }
            else
            {
                //Spawn Audio when anything interacts with this collider
                audioManager.CreateAudioSource(gameObject, audioSource, followObject, destroyTheObject, triggerOnlyOnce);
            }

        }*/
    }
}