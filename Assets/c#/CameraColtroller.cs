using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColtroller : MonoBehaviour
{
    public Transform target1, target2;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - (target1.position + target2.position) / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = (target1.position + target2.position) / 2 + offset;
    }
}

