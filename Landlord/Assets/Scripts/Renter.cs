using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renter : MonoBehaviour
{
    public int happiness;
    public int expectRent;
    // Start is called before the first frame update

    // private float time;
    // public float period;

    public void updateExpectedRent(int value)
    {
        expectRent = (int)(value * (80+Random.Range(0,41)) / 100.0);
    }
    
    public void updateHappiness(int rent)
    {
        if (rent == 0) happiness = 100;
        else happiness = (int)(100.0 * (double)expectRent/(double)rent);
    }

    public bool checkLeaveOrNot() {

        int possibility=Random.Range(1,101);
        int leavePossibility = (100-happiness)-20;
        if(possibility<=leavePossibility){
            return true;
            Destroy(this.gameObject);
        }

        return false;
    }

    void Start()
    {
        // time=0.0f;
        // period=1.0f;
    }
}
