using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float followSpeed;
    public float yOffset;
    public float xOffset;
    public float smoothing;
    

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        //offset = transform.position-target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPositon = target.position;
        //target.position + offset;
      

        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPositon, followSpeed*Time.deltaTime);  
        transform.position = new Vector3(smoothPos.x+xOffset, smoothPos.y+yOffset, -10f);
    }
}

