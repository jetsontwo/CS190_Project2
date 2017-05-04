using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step_Trigger : AkTriggerBase {
    
    public void Step()
    {
        if (triggerDelegate != null)
            triggerDelegate(null);
    }
}
