using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** Singleton Design System: https://gamedevbeginner.com/singletons-in-unity-the-right-way/
**                          https://www.youtube.com/watch?v=EI1KJv8owCg&ab_channel=GameDevHQ
**                          https://www.youtube.com/watch?v=tcatvGLvCDc&ab_channel=ThousandAnt
** Scriptable Objects: https://www.youtube.com/watch?v=raQ3iHhE_Kk&ab_channel=Unity
**
*/

public class MasterSingleton : MonoBehaviour
{
    public static MasterSingleton main {get; private set;}
    public GUIManager GUIManagerScript {get; private set;}
    public PlayerControl playerControlScript {get; private set;}
    void Awake()
    {
        //If there is a duplicated main, delete it
        if (main != null && main != this)
        {
            Destroy(this.gameObject);
            return;
        }
        main = this;
        GUIManagerScript = GetComponentInChildren<GUIManager>();
        playerControlScript = GetComponentInChildren<PlayerControl>();
    }

    public void printSomething()
    {
        print("lol this is my first singleton test!");
    }
}
