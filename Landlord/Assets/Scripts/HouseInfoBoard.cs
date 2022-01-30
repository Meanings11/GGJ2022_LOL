using UnityEngine;
using UnityEngine.UI;

public class HouseInfoBoard : MonoBehaviour
{
    // level
    public Sprite[] starImages;
    public Image star;
    public Image tableImage;
    public int level = 0;
    public bool isLocked = true;
    public int cost;

    private int rentVal = 0;
    public Button increaseBtn, decreaseBtn;

    public Text rentText;
    public Text statusTitleText;
    public Text costText;

    private static string LOCKED_TITLE = "LOCKED";
    private static string UPGRADE_TITLE = "UPGRADE";

    private Color color1 = new Color(1f, 1f, 1f, 1f);
    private Color color2 = new Color(0.196f, 0.196f, 0.196f);
    private Color maskColor = new Color(0f, 0f, 0f, 0.4f);
    private Color color3 = new Color(0.82f, 0.31f, 0.31f, 1f);
    
    private void FixedUpdate()
    {
        if (level < starImages.Length)
        {
            star.sprite = starImages[level];
        }

        rentText.text = Utils.HandleMoney(rentVal);
        costText.text = Utils.HandleMoney(cost);

        increaseBtn.interactable = !isLocked;
        decreaseBtn.interactable = !isLocked;

        if (isLocked)
        {
            statusTitleText.text = LOCKED_TITLE;
            statusTitleText.color = color1;
            costText.color = color1;
            tableImage.color = maskColor;
        }
        else
        {
            statusTitleText.text = UPGRADE_TITLE;
            statusTitleText.color = color2;
            costText.color = color2;
            tableImage.color = color1;
        }

        if (level == 3)
        {
            statusTitleText.gameObject.SetActive(false);
            costText.text = "FINISHED!";
            costText.color = color3;
        }

    }

    public void UpgradeHouse(int newLevel)
    {
        if (level == 3)
        {
            return;
        }
        level = newLevel;
    }

    public void OnClickIncreaseBtn(int rentStep)
    {
        if (!isLocked)
        {
            rentVal += rentStep;
        }
    }

    public void OnClickDecreaseBtn(int rentStep)
    {
        if (!isLocked)
        {
            if (rentVal == 0)
            {
                return;
            }
            rentVal -= rentStep;    
        }
    }
}
