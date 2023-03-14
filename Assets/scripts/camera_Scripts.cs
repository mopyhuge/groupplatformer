using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Scripts : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed;

    public Vector3 offeset;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        smoothSpeed = 0.125f;
        offeset = new Vector3(0, 2, -10);
    }

    private void LateUpdate()
    {
        Vector3 goalPos = target.position + offeset;
        Vector3 smoothPos = Vector3.Lerp(transform.position,goalPos,smoothSpeed);
        transform.position = smoothPos;

        transform.LookAt(target);
    }
}
