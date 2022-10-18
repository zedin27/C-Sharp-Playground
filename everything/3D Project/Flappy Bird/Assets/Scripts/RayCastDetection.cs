using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDetection : MonoBehaviour
{
    public GameObject beam;
    private float distance = 4.2f;
    public float yRange = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // RaycastHit hit;
        Vector3 down = beam.transform.TransformDirection(Vector3.down) * distance;
        // downray = Physics.Raycast(transform.position, down, 10);
        // print(down);

        if (Physics.Raycast(beam.transform.position, down, 10))
        {
            print(down);
            Debug.DrawRay(beam.transform.position, down, Color.cyan);
            print("There is something in front of the object!");
        }
        // CheckForColliders();
    }

    void CheckForColliders()
    {
        // Ray ray = new Ray(transform.position, transform.up);
        // if (Physics.Raycast(ray, out RaycastHit hit))
        // {
        //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.cyan);
        //     Debug.Log("I hit " + hit.collider.gameObject.name);
        // }
        // else
        // {
        //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
        //     Debug.Log("Did not Hit");
        // }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class RayCastDetection : MonoBehaviour
// {
//     Ray ray;
//     // Start is called before the first frame update
//     void Start()
//     {
//         Ray ray = new Ray(transform.position, transform.up);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         CheckForColliders();
//     }

//     void CheckForColliders()
//     {
//         if (Physics.Raycast(ray, out RaycastHit hit))
//         {
//             Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.cyan);
//             Debug.Log("I hit " + hit.collider.gameObject.name);
//         }
//     }
// }
