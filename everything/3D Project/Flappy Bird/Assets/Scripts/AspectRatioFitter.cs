using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectRatioFitter : MonoBehaviour
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
