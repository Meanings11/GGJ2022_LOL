using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LosePopup : MonoBehaviour
{
	public CanvasGroup _canvasGroup;
	public Image mask;
	
	private static float TIME_DURATION = 0.25f;

	public void OpenLoseWindow()
	{
		mask.color = new Color(0f, 0f, 0f, 0.5f);
		_canvasGroup.gameObject.SetActive(true);
		_canvasGroup.DOFade(1, TIME_DURATION).OnComplete(() =>
		{
			_canvasGroup.interactable = true;
		});
	}
}