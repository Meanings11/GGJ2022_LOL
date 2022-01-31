using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class RenterEvictButton : MonoBehaviour
{
    public Image mask;
    public GameObject Renter;

    public Text nameText;
    public Text happinessText;

    public CanvasGroup selfCanvasGroup;

    private static float TIME_DURATION = 0.25f;

    private void Start()
    {
        selfCanvasGroup.gameObject.SetActive(false);
    }

    public void OpenPopup()
    {
        mask.color = new Color(0f, 0f, 0f, 0.5f);
        nameText.text = Renter.GetComponent<Renter>().name;
        happinessText.text = Renter.GetComponent<Renter>().happiness + "%";
        selfCanvasGroup.gameObject.SetActive(true);
        selfCanvasGroup.DOFade(1, TIME_DURATION).OnComplete(() =>
        {
            selfCanvasGroup.interactable = true;
        });
    }
    
    public void ClosePopup()
    {
        selfCanvasGroup.interactable = false;
        selfCanvasGroup.alpha = 0;
        mask.color = new Color(0f, 0f, 0f, 0f);
        selfCanvasGroup.gameObject.SetActive(false);
    }
}
