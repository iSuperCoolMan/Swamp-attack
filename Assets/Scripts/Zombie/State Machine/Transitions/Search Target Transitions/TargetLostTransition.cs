using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLostTransition : TargetSearchTransition
{
    private void Update()
    {
        if (SearchTargetInRadius(Radius) == false)
            NeedTranzit = true;
    }
}
