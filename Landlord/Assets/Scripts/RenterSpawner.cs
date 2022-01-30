using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenterSpawner : MonoBehaviour
{
    public Renter prefabRenter;
    public string[] nameArray={"James", "Robert", "John", "Michael", "William", 
    "Mary", "Patricia", "Linda", "Elizabeth", "Barbara"};

    public static int amount;
    public Apartment apartment;

    private float time;
    public float period;

    public Renter renter;

    // Start is called before the first frame update
    void Start()
    {
        amount=0;
        time=0.0f;
        period=1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>time){//change season or month?
            time += period; 

            renter = Instantiate(prefabRenter);
            renter.expectRent = (int)(apartment.value * (80+Random.Range(0,41)) / 100.0);
            int possibility = Random.Range(1, 101);
            double generatePossibility = apartment.reputation * 0.5 + (double)(renter.expectRent) / apartment.rent * 0.5;
            Debug.Log("expectRent"+renter.expectRent.ToString());
            Debug.Log("generatePossibility"+generatePossibility.ToString());
            if(possibility<=generatePossibility){
                Invoke("CreateRenter", 0);
            }
            else{
                Destroy(renter.gameObject, 0.0f);
            }
        }
    }

    public void CreateRenter(){
        amount++;
        renter.name="Renter_"+nameArray[Random.Range(0, 10)];
        renter.happiness=(int)(100.0 * (double)apartment.rent/(double)renter.expectRent);
    }
}
