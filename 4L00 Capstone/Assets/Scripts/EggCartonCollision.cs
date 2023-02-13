using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCartonCollision : MonoBehaviour
{
    [SerializeField] private IntermLevelManger manger;
    private MeshCollider meshCollider;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CashRegistar"))
        {
            manger.IncreasePanicRoomState(1);
        }
    }
}
