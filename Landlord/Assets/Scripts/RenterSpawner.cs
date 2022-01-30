using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenterSpawner : MonoBehaviour
{

    public static RenterSpawner instance; 
    public Renter prefabRenter;
    public GameManager gameManager;
    
    public Renter renter;
    public string[] nameArray={"Liam","Olivia","Noah","Emma","Oliver","Ava","Elijah","Charlotte",
	"William","Sophia","James","Amelia","Benjamin","Isabella","Lucas","Mia",
	"Henry","Evelyn","Alexander","Harper","Robert","John","Michael","Mary","Patricia","Linda","Elizabeth","Barbara"};

    // private float time;
    // public float period;

    void Awake() {
        if (instance == null) {
            instance = this;
        }    
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // time=0.0f;
        // period=1.0f;
    }

    public void spawn(Apartment ap)
    {
        renter = Instantiate(prefabRenter);
        renter.updateExpectedRent(ap.value);

        int possibility = Random.Range(1, 101);
        double generatePossibility = gameManager.reputation * 0.5 + 
                                    (double)(renter.expectRent) / ap.rent * 0.5;
        if(possibility<=generatePossibility){
            ap.occupied=true;
            renter.name="Renter_"+nameArray[Random.Range(0, nameArray.Length)];
            renter.updateHappiness(ap.rent);
            ap.renter=renter;
            gameManager.renters.Add(renter);
        }
        else{
            Destroy(renter.gameObject);
        }
    }
}
