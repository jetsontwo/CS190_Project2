using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Trigger : AkTriggerBase
{
    public void Attack()
    {
        if (triggerDelegate != null)
            triggerDelegate(null);
    }
}
