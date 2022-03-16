using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position-target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPositon = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPositon, smoothing*Time.deltaTime);  
    }
}

