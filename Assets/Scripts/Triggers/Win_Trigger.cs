using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Trigger : AkTriggerBase
{

    public void Win()
    {
        if (triggerDelegate != null)
            triggerDelegate(null);
    }   // Use this for initialization
}
