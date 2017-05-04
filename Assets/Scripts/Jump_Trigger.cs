using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Trigger : AkTriggerBase
{

    public void Jump()
    {
        if (triggerDelegate != null)
            triggerDelegate(null);
    }   // Use this for initialization
}
