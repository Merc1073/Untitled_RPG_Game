using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;

    private void Update()
    {
        transform.position = player.transform.position;

        //Vector3 newRotation = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z);

        //gameObject.transform.eulerAngles = newRotation;

        transform.rotation = player.transform.rotation;
    }

}
