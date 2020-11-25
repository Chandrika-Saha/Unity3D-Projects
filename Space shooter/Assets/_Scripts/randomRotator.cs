using UnityEngine;
using System.Collections;

public class randomRotator : MonoBehaviour {

    public float tumble;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
    
}
