using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float scrollSpeed;
    public float cameraHeight;
    private Vector3 velocity = Vector3.zero;
    public Transform cameraY;
    // Start is called before the first frame update
    private void Start()
    {
        cameraY = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = new Vector3(player.position.x, player.position.y + cameraHeight, -10);
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, scrollSpeed);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (cameraY.position.y < -10)
        {
            cameraY.position = new Vector3(cameraY.position.x, -8, cameraY.position.z);
        }
    }
}
