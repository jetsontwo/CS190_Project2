using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Trigger : AkTriggerBase
{

    public void Damage()
    {
        if (triggerDelegate != null)
            triggerDelegate(null);
    }   // Use this for initialization
}
