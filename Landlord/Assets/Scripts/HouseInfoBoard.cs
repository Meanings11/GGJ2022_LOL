using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseInfoBoard : MonoBehaviour
{
    [Range(0, 10)]public int levelVal;
    public Image levelFillImg;
    public bool isLocked;
    public bool canUpdate;
    public int cost;
    public GameObject lockMask;
    public Sprite lightStar, darkStar;
    public Image star;
    
    
    public Text statusTitleText;
    public Text costText;

    private static string LOCKED_TITLE = "LOCKED";
    private static string UNLOCKED_TITLE = "BUY";
    private static string UPGRADE_TITLE = "UPGRADE";
    
    private Color color1 = Color.white;
    private Color color2 = new Color(0.196f, 0.196f, 0.196f);

    private void Start()
    {
        levelFillImg.fillAmount = 0f;
    }

    private void FixedUpdate()
    {
        if (isLocked)
        {
            star.sprite = darkStar;
            statusTitleText.text = LOCKED_TITLE;
            statusTitleText.color = color1;
            costText.text = HandleCost(cost);
            costText.color = color1;
            lockMask.SetActive(true);
        }
        else if (canUpdate)
        {
            star.sprite = lightStar;
            statusTitleText.text = UPGRADE_TITLE;
            statusTitleText.color = color2;
            costText.text = HandleCost(cost);
            costText.color = color2;
            lockMask.SetActive(false);
        }
        else
        {
            star.sprite = lightStar;
            statusTitleText.text = UNLOCKED_TITLE;
            statusTitleText.color = color2;
            costText.text = HandleCost(cost);
            costText.color = color2;
            lockMask.SetActive(false);
        }

        levelFillImg.fillAmount = levelVal / 10f;
    }

    private string HandleCost(int costVal)
    {
        string res = "";
        int cnt = 0;
        while (costVal > 0)
        {
            if (cnt == 3)
            {
                res =  "," + res;
                cnt = 0;
            }
            res = costVal % 10 + res;
            cnt++;
            costVal /= 10;
        }
        return res;
    }
}
