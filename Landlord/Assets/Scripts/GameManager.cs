using System;
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

    public GameObject firstHouse;

    void Awake() {
        if (instance == null) {
            instance = this;
        }    
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        balance = 2000;
        reputation = 100;
        apartments = new List<Apartment>();
        renters = new List<Renter>();

        addApartment(firstHouse);
    }

    public void enterNewMonth(){
        updateMonthlyBalance();
        updateMonthlyReputation();

        for (int i = 0; i < apartments.Count; i++) {
            apartments[i].monthUpdate();
        }
    }

    public void updateMonthlyBalance() {
        for (int i = 0; i < apartments.Count; i++) {
            if (apartments[i].occupied) balance += apartments[i].rent;
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

    public void addApartment(GameObject house){
        if (balance > PlayerStats.buildingCost)
        {
            house.SetActive(true);
            Apartment new_ap = house.GetComponent<Apartment>();
            new_ap.level++;
            apartments.Add(new_ap); // push to the List
            
            balance -= PlayerStats.buildingCost;
        }
    }
}
