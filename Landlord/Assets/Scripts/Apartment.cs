using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartment : MonoBehaviour
{
    public int rent;
    public int level = 1;
    public int nxtUpgradeCost = 1000;
    public int maintFee = 300;
    public int value = 500;
    public bool occupied = false;
    public Renter renter;

    SpriteRenderer spriteRenderer;

    public Sprite floor1;
    public Sprite floor2;
    public Sprite floor3;
    public GameObject upgradeEffect;

    public void upgrade() {
        // if (PlayerStats.balance < nxtUpgradeCost) return false;
        level++;
        maintFee = Helper.roundToTen(maintFee*Math.Exp(0.3));
        value = Helper.roundToTen((nxtUpgradeCost/10 + maintFee) * 1.25);
        nxtUpgradeCost = Helper.roundToTen(nxtUpgradeCost*Math.Exp(0.5));
        updateSprite();
        invokeEffect();

        renter.updateExpectedRent(value);
    }

    private void updateSprite(){
        if (level == 1) {
            spriteRenderer.sprite = floor1;
        } else if (level ==2) {
            spriteRenderer.sprite = floor2;
        } else if (level >= 3) {
            spriteRenderer.sprite = floor3;
        }
    }

    public bool renterUpdate() {
        if (!occupied) {
            RenterSpawner.instance.spawn(this);
        } else {
            if (renter.checkLeaveOrNot()) {
                Debug.Log("left");
                occupied = false;
                renter = null;
                return true;
            } 
        }

        return false;
    }

    public void AddRent(int step)
    {
        if (step < 0 && rent <= 0)
        {
            return;
        }
        rent += step;
        if (occupied) renter.updateHappiness(rent);
    }

    private void invokeEffect(){
        upgradeEffect = Instantiate(upgradeEffect);
        // Destroy(upgradeEffect, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rent = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        occupied = false;
    }
}
