using System;
using UnityEngine;
using UnityEngine.UI;

public class HouseInfoBoard : MonoBehaviour
{
    public Apartment matchedApt;
    // level
    public Sprite[] starImages;
    public Image star;
    public Image tableImage;

    public Button increaseBtn, decreaseBtn;

    public Text rentText;
    public Text statusTitleText;
    public Text costText;

    private static string LOCKED_TITLE = "LOCKED";
    private static string UPGRADE_TITLE = "UPGRADE";

    private static int RENT_STEP = 100;

    private Color color1 = new Color(1f, 1f, 1f, 1f);
    private Color color2 = new Color(0.196f, 0.196f, 0.196f);
    private Color maskColor = new Color(0f, 0f, 0f, 0.4f);
    private Color color3 = new Color(0.82f, 0.31f, 0.31f, 1f);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClickBoard();
        }
    }

    private void FixedUpdate()
    {
        if (matchedApt.level < starImages.Length)
        {
            star.sprite = starImages[matchedApt.level];
        }

        rentText.text = Utils.HandleMoney(matchedApt.rent);
        costText.text = Utils.HandleMoney(matchedApt.nxtUpgradeCost);

        increaseBtn.interactable = matchedApt.level != 0;
        decreaseBtn.interactable = matchedApt.level != 0;

        if (matchedApt.level == 0)
        {
            statusTitleText.text = LOCKED_TITLE;
            statusTitleText.color = color1;
            costText.color = color1;
            tableImage.color = maskColor;
        }
        else if (matchedApt.level == 3)
        {
            statusTitleText.gameObject.SetActive(false);
            costText.text = "FINISHED!";
            costText.color = color3;
        }
        else
        {
            statusTitleText.text = UPGRADE_TITLE;
            statusTitleText.color = color2;
            costText.color = color2;
            tableImage.color = color1;
        }
    }

    public void OnClickBoard()
    {
        if (matchedApt.level == 0)
        {
            GameManager.instance.addApartment(matchedApt.gameObject);
        }
        else if (matchedApt.level > 0 && matchedApt.level < 3)
        {
            matchedApt.upgrade();
        }
    }

    public void OnClickIncreaseBtn()
    {
        if (matchedApt.level != 0)
        {
            matchedApt.AddRent(RENT_STEP);
        }
    }

    public void OnClickDecreaseBtn()
    {
        if (matchedApt.level != 0)
        {
            matchedApt.AddRent(-RENT_STEP);  
        }
    }
}
