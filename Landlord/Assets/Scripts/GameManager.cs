using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//go to next turn, update UI
public class GameManager : MonoBehaviour { 

   public static GameManager instance; 
   public List<Apartment> apartments;
   public List<Renter> renters;


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
        PlayerStats.balance = 2000;
        PlayerStats.reputation = 100;
        apartments = new List<Apartment>();
        renters = new List<Renter>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMonthlyBalance() {
        for (int i = 0; i < apartments.Count; i++) {
            PlayerStats.balance += apartments[i].rent;
        }
   }

   public void updateMonthlyReputation() {
       if (renters.Count ==0 ) return;

       int temp = 0;
       for (int i = 0; i < renters.Count; i++) {
           temp += renters[i].happiness;
       }

       PlayerStats.reputation = temp/renters.Count > 0 ? temp/renters.Count : 0; 
   }

    public void addApartment(){
        if (PlayerStats.balance > PlayerStats.buildingCost) {
            GameObject gameobj = (GameObject)Instantiate(Resources.Load("ap_obj"));
            Apartment new_ap = gameobj.GetComponent<Apartment>();
            apartments.Add(new_ap); // push to the List
            // PlayerStats.balance -= PlayerStats.buildingCost;
        }
        Debug.Log(apartments.Count);
    }

    public void upgradeApartment(int index) {
        apartments[index].upgrade();
        Debug.Log((apartments.Count));
    }
}
