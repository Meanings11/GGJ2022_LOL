using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renter : MonoBehaviour
{
    public int happiness;
    public int expectRent;
    // Start is called before the first frame update

    private float time;
    public float period;
    void Start()
    {
        expectRent=1;
        time=0.0f;
        period=1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>time){
            /*time += period;

            int possibility=Random.Range(1,101);
            int leavePossibility = (100-happiness)-20;
            if(possibility<=leavePossibility){
                Destroy(this.gameObject);
            }*/
        }
        
    }
}
