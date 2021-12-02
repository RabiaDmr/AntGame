using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ant;

    
    void Update()
    {
        transform.position = new Vector3(ant.position.x + 2, transform.position.y, transform.position.z);
    }
}
