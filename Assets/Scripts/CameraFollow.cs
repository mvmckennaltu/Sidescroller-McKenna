using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float scrollSpeed;
    public float cameraHeight;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.TransformPoint(new Vector3(0, cameraHeight, -10));
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, scrollSpeed);
    }
}
