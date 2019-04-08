using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollspeed;
    public float tileSizeZ;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float NewPosition = Mathf.Repeat(Time.time * scrollspeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * NewPosition;
    }
}
