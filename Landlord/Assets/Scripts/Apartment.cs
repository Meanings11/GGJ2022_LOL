using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartment : MonoBehaviour
{
    public int rent = 10;
    public int level = 1;
    public int buildingCost = 1000;
    public int nxtUpgradeCost = 1000;
    public int maintFee = 300;
    public int reputation;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        rent=10;
        reputation=10;
        value=10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
