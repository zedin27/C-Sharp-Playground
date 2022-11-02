using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** RaycastHit: https://docs.unity3d.com/ScriptReference/RaycastHit.html
** Raycast: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
*/
public class RayCastDetection : MonoBehaviour
{
    public UIManager UIManagerScript;
    public ParticleSystem particles;
    public PlayerControl playerControlScript;
    private RaycastHit hit;
    public bool passed;
    void Start()
    {
        UIManagerScript = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        playerControlScript = GameObject.Find("Tomato").GetComponent<PlayerControl>();
        passed = false;
    }

    void Update()
    {
        Vector3 beamDown = transform.TransformDirection(Vector3.down);
        Ray ray = new Ray(transform.position, beamDown);

        if (!passed)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Player" && !UIManagerScript.success)
                {
                    UIManagerScript.incrementScore = true;
                    UIManagerScript.score++;
                }
                if (UIManagerScript.incrementScore)
                    UIManagerScript.success = true;
                Debug.DrawRay(transform.position, hit.point - transform.position);
            }
        }
    }
}