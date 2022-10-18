using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDetection : MonoBehaviour
{
    public GameObject beam;
    public UIManager UIManagerScript;
    private RaycastHit hit;
    private bool passed;
    // Start is called before the first frame update
    void Start()
    {
        UIManagerScript = GameObject.Find("Score_text").GetComponent<UIManager>(); //useless atm
        passed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 down = beam.transform.TransformDirection(Vector3.down);
        Ray ray = new Ray(beam.transform.position, down);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player" && passed == false)
            {
                print("laser touched player");
                passed = true;
            }
            Debug.DrawRay(beam.transform.position, hit.point - beam.transform.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Tomato")
            print("I'm hitting a pipe");
    }
}