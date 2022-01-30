using UnityEngine;
using UnityEngine.UI;

public class HouseInfoBoard : MonoBehaviour
{
    // level
    public Sprite[] starImages;
    public Image star;
    public int level = 0;
    public bool isLocked = true;
    public int cost;
    public GameObject lockMask;
    
    private int rentVal = 0;
    public Button increaseBtn, decreaseBtn;

    public Text rentText;
    public Text statusTitleText;
    public Text costText;

    private static string LOCKED_TITLE = "LOCKED";
    private static string UPGRADE_TITLE = "UPGRADE";
    
    private Color color1 = Color.white;
    private Color color2 = new Color(0.196f, 0.196f, 0.196f);
    
    private void FixedUpdate()
    {
        star.sprite = starImages[level];
        
        rentText.text = Utils.HandleMoney(rentVal);
        costText.text = Utils.HandleMoney(cost);

        increaseBtn.interactable = !isLocked;
        decreaseBtn.interactable = !isLocked;

        lockMask.SetActive(isLocked);
        
        if (isLocked)
        {
            statusTitleText.text = LOCKED_TITLE;
            statusTitleText.color = color1;
            costText.color = color1;
        }
        else
        {
            statusTitleText.text = UPGRADE_TITLE;
            statusTitleText.color = color2;
            costText.color = color2;
        }

    }

    public void UpgradeHouse(int newLevel)
    {
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
