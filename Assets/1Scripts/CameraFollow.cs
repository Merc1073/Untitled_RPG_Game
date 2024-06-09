using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

    public float smoothSpeed;
    public Vector3 offset;

    bool ranOnce = false;

    private void FixedUpdate()
    {

        if(!player && !ranOnce)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player)
        {
            Vector3 desiredPosition = player.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }

    }
}
