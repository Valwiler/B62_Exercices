using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject player;
    public float moveBuffer = 0.15f;
    private Camera cam;
    private float cameraZ;
    private Vector3 velocity = Vector3.zero;


    private void Start()
    {
        cameraZ = transform.position.z;

        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player)
        {
            var delta = player.transform.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraZ));
            var destination = transform.position + delta;
            destination.z = cameraZ;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, moveBuffer);
        }
    }
}