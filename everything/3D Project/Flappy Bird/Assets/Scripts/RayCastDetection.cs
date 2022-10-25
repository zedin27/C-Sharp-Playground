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
    public UIManager UIManagerScript;
    public ParticleSystem particles;
    private RaycastHit hit;
    private bool passed;
    // Start is called before the first frame update
    void Start()
    {
        UIManagerScript = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        // particles = GameObject.Find("Particles").GetComponent<ParticleSystem>();
        // particles.Pause();
        passed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 beamDown = transform.TransformDirection(Vector3.down);
        Ray ray = new Ray(transform.position, beamDown);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player" && passed == false)
            {
                passed = true;
                UIManagerScript.score++;
                // particles.Play();
            }
            Debug.DrawRay(transform.position, hit.point - transform.position);
        }
    }
}