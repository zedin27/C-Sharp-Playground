// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// /*
// ** RaycastHit: https://docs.unity3d.com/ScriptReference/RaycastHit.html
// ** Raycast: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
// ** 
// */
// public class RayCastDetection : MonoBehaviour
// {
//     public UIManager UIManagerScript;
//     public ParticleSystem particles;
//     public PlayerControl playerControlScript;
//     private RaycastHit hit;
//     public bool passed;
//     // Start is called before the first frame update
//     void Start()
//     {
//         UIManagerScript = GameObject.Find("UI_Manager").GetComponent<UIManager>();
//         playerControlScript = GameObject.Find("Tomato").GetComponent<PlayerControl>();
//         passed = false;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Vector3 beamDown = transform.TransformDirection(Vector3.down);
//         Ray ray = new Ray(transform.position, beamDown);

//         if (Physics.Raycast(ray, out hit))
//         {
//             if (hit.collider.tag == "Player" && passed == false)
//             {
//                 passed = true;
//                 UIManagerScript.score++;
//                 if (passed)
//                 {
//                     playerControlScript.passedBeam = true;
//                 }
//                 else
//                     passed = false;
//                     playerControlScript.passedBeam = false;
//             }
//             Debug.DrawRay(transform.position, hit.point - transform.position);
//         }
//     }
// }

//TRYING TO FIX CODE AFTER THIS LINE
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
    public PlayerControl playerControlScript;
    private RaycastHit hit;
    public bool passed;
    // Start is called before the first frame update
    void Start()
    {
        UIManagerScript = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        playerControlScript = GameObject.Find("Tomato").GetComponent<PlayerControl>();
        passed = false;
        playerControlScript.passedBeam = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 beamDown = transform.TransformDirection(Vector3.down);
        Ray ray = new Ray(transform.position, beamDown);

        if (!passed)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Player" && !playerControlScript.passedBeam)
                {
                    playerControlScript.passedBeam = !playerControlScript.passedBeam;
                    UIManagerScript.score++;
                }
                Debug.DrawRay(transform.position, hit.point - transform.position);
            }
        }
        else
            playerControlScript.passedBeam = false;
    }
}