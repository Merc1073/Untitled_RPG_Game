using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    [SerializeField] private GameObject reticle;

    private float rotateVelocity;
    //private float rotateSpeedMovement;

    void Update()
    {
        Quaternion rotationToLookAt = Quaternion.LookRotation(reticle.transform.position - transform.position);
        float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, 0 * (Time.deltaTime * 5));
        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }
}
