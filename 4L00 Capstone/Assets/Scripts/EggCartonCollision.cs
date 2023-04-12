using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EggCartonCollision : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset ActionAsset;

    [Header("Controller Vibrator")]
    [SerializeField]
    private ControllerVibration contVibrate;

    [SerializeField]
    private GameObject JoyStitckR, JoyStitckL;

    [SerializeField]
    private Sc_PanicDisorderR1 manger;
    private MeshCollider meshCollider;

    private int layerMask = 11;

    private void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CashRegistar"))
        {
            manger.IncreasePanicRoomState(1);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.layer == layerMask)
        {
            contVibrate.StartControllerVibrations(0.75f, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CashRegistar"))
        {
            manger.IncreasePanicRoomState(1);
        }
    }
}
