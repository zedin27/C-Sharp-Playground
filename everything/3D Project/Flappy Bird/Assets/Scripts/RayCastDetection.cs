using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** RaycastHit: https://docs.unity3d.com/ScriptReference/RaycastHit.html
** Raycast: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
** 
*/
public class RayCastDetection : MonoBehaviour
{
    public GameObject beam;
    public UIManager UIManagerScript;
    public UIManager UIManagerScript1;
    private RaycastHit hit;
    private bool passed;
    // Start is called before the first frame update
    void Start()
    {
        UIManagerScript = GameObject.Find("UI_Manager").GetComponent<UIManager>();
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
                passed = true;
                UIManagerScript.score++;
            }
            Debug.DrawRay(beam.transform.position, hit.point - beam.transform.position);
        }
    }
}