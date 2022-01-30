using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//go to next turn, update UI
public class GameManager : MonoBehaviour { 

   public static GameManager instance; 
   // Data
    public int balance;
   public int reputation;
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
        balance = 2000;
        reputation = 100;
        apartments = new List<Apartment>();
        renters = new List<Renter>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void enterNewMonth(){
        updateMonthlyBalance();
        updateMonthlyReputation();
    }

    public void updateMonthlyBalance() {
        for (int i = 0; i < apartments.Count; i++) {
            balance += apartments[i].rent;
            balance -= apartments[i].maintFee;
        }
   }

   public void updateMonthlyReputation() {
       if (renters.Count ==0 ) return;

       int temp = 0;
       for (int i = 0; i < renters.Count; i++) {
           temp += renters[i].happiness;
       }

       reputation = temp/renters.Count > 0 ? temp/renters.Count : 0; 
   }

    public void addApartment(){
        if (balance > PlayerStats.buildingCost) {
            GameObject gameobj = (GameObject)Instantiate(Resources.Load("building"));
            Apartment new_ap = gameobj.GetComponent<Apartment>();
            apartments.Add(new_ap); // push to the List
            // balance -= PlayerStats.buildingCost;
        }
        Debug.Log(apartments.Count);
    }

    public void upgradeApartment(int index) {
        apartments[index].upgrade();
        Debug.Log((apartments.Count));
    }
}
