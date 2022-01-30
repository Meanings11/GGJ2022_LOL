using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenterSpawner : MonoBehaviour
{
    public Renter prefabRenter;
    public GameManager gameManager;
    
    public Renter renter;
    public string[] nameArray={"Liam","Olivia","Noah","Emma","Oliver","Ava","Elijah","Charlotte",
	"William","Sophia","James","Amelia","Benjamin","Isabella","Lucas","Mia",
	"Henry","Evelyn","Alexander","Harper","Robert","John","Michael","Mary","Patricia","Linda","Elizabeth","Barbara"};

    private float time;
    public float period;
    
    // Start is called before the first frame update
    void Start()
    {
        time=0.0f;
        period=1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>time){//change season or month?
            time += period; 

            for(int i=0;i<gameManager.apartments.Count;i++){
                if(!gameManager.apartments[i].occupied){
                    renter = Instantiate(prefabRenter);
                    renter.expectRent = (int)(gameManager.apartments[i].value * (80+Random.Range(0,41)) / 100.0);

                    int possibility = Random.Range(1, 101);
                    double generatePossibility = PlayerStats.reputation * 0.5 + 
                                                (double)(renter.expectRent) / gameManager.apartments[i].rent * 0.5;
                    if(possibility<=generatePossibility){
                        gameManager.apartments[i].occupied=true;
                        renter.name="Renter_"+nameArray[Random.Range(0, nameArray.Length)];
                        renter.happiness=(int)(100.0 * (double)gameManager.apartments[i].rent/(double)renter.expectRent);
                        gameManager.apartments[i].renter=renter;
                    }
                    else{
                        Destroy(renter.gameObject);
                    }
                }
            }
        }
    }
}
