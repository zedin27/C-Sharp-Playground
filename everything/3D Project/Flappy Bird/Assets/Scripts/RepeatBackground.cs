using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    public float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= startPos.z - repeatWidth) // pos.x < -0.x with current values basically or try -1 if you want to hardcode it (not recommend)
            transform.position = startPos;
    }
}
