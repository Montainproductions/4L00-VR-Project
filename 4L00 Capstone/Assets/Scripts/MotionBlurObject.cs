using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MotionBlurObject : MonoBehaviour
{
    [SerializeField]
    private GameObject GameObject;
    private Rigidbody rb;

    private float count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 300f, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 3)
        {
            Instantiate(GameObject, transform.position, Quaternion.identity);
        }
        count += Time.deltaTime;
    }
}
