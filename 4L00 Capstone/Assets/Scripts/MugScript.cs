using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugScript : MonoBehaviour
{
    [SerializeField] private Sc_ScizophreniaR2 levelmanager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            levelmanager.MugHitFool();
        }
    }
}
