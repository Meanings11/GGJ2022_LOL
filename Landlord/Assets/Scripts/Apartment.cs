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
    public GameObject upgradeEffectPrefab;
    private GameObject effectObj;
    public AudioSource sound;

    public void upgrade() {
        if (GameManager.instance.balance < nxtUpgradeCost) return;
        GameManager.instance.balance -= nxtUpgradeCost;
        level++;
        maintFee = Helper.roundToTen(maintFee*Math.Exp(0.3));
        nxtUpgradeCost = Helper.roundToTen(nxtUpgradeCost*Math.Exp(0.5));
        value = Helper.roundToTen((nxtUpgradeCost/10 + maintFee) * 1.25);
        updateSprite();
        invokeEffect();

        AudioSource goodSound = Instantiate(sound);
        goodSound.Play();
        //Destroy(goodSound.gameObject);

        if (renter != null)
        {
            renter.updateExpectedRent(value);
        }
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

    public void invokeEffect()
    {
        effectObj = Instantiate(upgradeEffectPrefab, transform);
        Destroy(effectObj, 0.4f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rent = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        occupied = false;
    }

    private void OnMouseDown()
    {
        GameObject popup = GameObject.FindWithTag("Popup");
        if (popup != null)
        {
            popup.SetActive(true);
            RenterEvictButton re = popup.GetComponent<RenterEvictButton>();
            if (renter != null && re != null)
            {
                re.Renter = renter.gameObject;
                re.OpenPopup();
            }
        }
    }
}
