using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartment : MonoBehaviour
{
    public int rent{get;set;}
    public int level = 1;
    public int nxtUpgradeCost = 1000;
    public int maintFee = 300;
    public int value = 500;

    public bool upgrade() {
        // if (PlayerStats.balance < nxtUpgradeCost) return false;

        level++;
        maintFee = Helper.roundToTen(maintFee*Math.Exp(0.3));
        value = Helper.roundToTen((nxtUpgradeCost/10 + maintFee) * 1.25);
        nxtUpgradeCost = Helper.roundToTen(nxtUpgradeCost*Math.Exp(0.5));
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rent = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
