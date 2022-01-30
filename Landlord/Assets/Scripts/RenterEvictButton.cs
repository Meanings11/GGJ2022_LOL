using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class RenterEvictButton : MonoBehaviour
{
    public Image mask;
    public GameObject Renter;

    public Text name;

    public CanvasGroup confirmationCanvasGroup;
    public CanvasGroup selfCanvasGroup;

    private static float TIME_DURATION = 0.25f;

    private void Start()
    {
        confirmationCanvasGroup.gameObject.SetActive(false);
        selfCanvasGroup.gameObject.SetActive(false);
    }

    public void OpenPopup()
    {
        mask.color = new Color(0f, 0f, 0f, 0.5f);
        name.text = Renter.GetComponent<Renter>().name;
        PopupWindow(selfCanvasGroup);
    }

    void PopupWindow(CanvasGroup canvasGroup)
    {
        canvasGroup.gameObject.SetActive(true);
        canvasGroup.DOFade(1, TIME_DURATION).OnComplete(() =>
        {
            canvasGroup.interactable = true;
        });
    }

    public void EvictOnClick()
    {
        CloseWindow(selfCanvasGroup);
        PopupWindow(confirmationCanvasGroup);
    }

    void CloseWindow(CanvasGroup cg)
    {
        cg.interactable = false;
        cg.alpha = 0;
    }

    public void YesOnClick()
    {
        CloseWindow(confirmationCanvasGroup);
        if (Renter != null)
        {
            Renter.transform.parent.gameObject.SetActive(false);
        }

        ClosePopup();
    }

    public void NoOnClick()
    {
        CloseWindow(confirmationCanvasGroup);
        selfCanvasGroup.alpha = 1;
        selfCanvasGroup.interactable = true;
    }

    public void ClosePopup()
    {
        CloseWindow(selfCanvasGroup);
        mask.color = new Color(0f, 0f, 0f, 0f);
    }
}
