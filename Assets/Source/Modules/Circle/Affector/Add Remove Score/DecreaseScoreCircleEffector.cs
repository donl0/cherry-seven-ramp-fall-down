using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseScoreCircleEffector : CircleEffector<DuringRaceScoreHolder>
{
    private int _amount;
    
    public DecreaseScoreCircleEffector(int amount)
    {
        _amount = amount;
    }

    public override void Affect(DuringRaceScoreHolder value)
    {
        value.TrySpend(_amount);
    }
}
