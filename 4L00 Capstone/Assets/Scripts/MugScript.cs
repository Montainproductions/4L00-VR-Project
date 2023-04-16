using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugScript : MonoBehaviour
{
    [SerializeField] private Sc_ScizophreniaR2 levelmanager;
    private AudioSource cupFallingAudioSource;

    private void Start()
    {
        cupFallingAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            cupFallingAudioSource.Play();
            levelmanager.MugHitFool();
        }
    }
}
