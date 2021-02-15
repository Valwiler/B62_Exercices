using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    
    public GameObject player;
    public float moveBuffer = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private float cameraZ = 0;
    private Camera cam;
    

    void Start()
    {
        cameraZ = transform.position.z;
        
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
      
        if (player)
        {
            Vector3 delta = player.transform.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraZ));
            Vector3 destination = transform.position + delta;
            destination.z = cameraZ;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, moveBuffer);
        }
    }
}
