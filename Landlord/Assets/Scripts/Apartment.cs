using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartment : MonoBehaviour
{
    public int rent{get;set;}
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
    public GameObject[] childrenObject;
    public GameObject popWindow;

    public bool upgrade() {
        // if (PlayerStats.balance < nxtUpgradeCost) return false;

        level++;
        maintFee = Helper.roundToTen(maintFee*Math.Exp(0.3));
        value = Helper.roundToTen((nxtUpgradeCost/10 + maintFee) * 1.25);
        nxtUpgradeCost = Helper.roundToTen(nxtUpgradeCost*Math.Exp(0.5));
        updateSprite();
        invokeEffect();
        return true;
    }

    public void updateSprite(){
        if (level == 1) {
            spriteRenderer.sprite = floor1;
        } else if (level ==2) {
            spriteRenderer.sprite = floor2;
        } else if (level >= 3) {
            spriteRenderer.sprite = floor3;
        }
    }

    public void invokeEffect(){
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

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Debug.Log("yes2");
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                Debug.Log("Something was clicked!");
                GameObject parent = GameObject.Find("Canvas");
                popWindow = parent.transform.Find("PopWindow").gameObject;
                /*GameObject window = Instantiate(popWindow);
                window.transform.SetParent (GameObject.Find("Canvas").transform, false);*/
                popWindow.SetActive(true);
            }
            else{
                popWindow.SetActive(false);
            }
        }
    }
}
