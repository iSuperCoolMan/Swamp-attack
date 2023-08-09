using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetFoundTransition : TargetSearchTransition
{
    private void Update()
    {
        if (SearchTargetInRadius(Radius))
            NeedTranzit = true;
    }
}
