using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
** Aspect Ratio for all devices: https://stackoverflow.com/a/55512751/6017248
*/

public class AspectRatio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        var canvasScaler = GetComponent<CanvasScaler>();
        var ratio = Screen.height / (float) Screen.width;
        var rr = canvasScaler.referenceResolution;
        canvasScaler.matchWidthOrHeight = (ratio < rr.x / rr.y) ? 1 : 0;
    }
}
