using System;
using UnityEngine;
using UnityEngine.UI;

public class CalenderTimer : MonoBehaviour
{
	public Image[] number;
	public Sprite[] digits;
	public int month = 1;
	public Image fillImage;

	private int oldMonth = 1;

	public float timespeed = 0.1f;

	private void Start()
	{
		ChangeDay(month);
		oldMonth = month;
		fillImage.fillAmount = 0f;
	}

	private void FixedUpdate()
	{
		
		if (fillImage.fillAmount == 1f)
		{
			fillImage.fillAmount = 0f;

			month++;
			if (month == 13) month = 1;
			GameManager.instance.enterNewMonth();
		}
		else
		{
			fillImage.fillAmount += Time.deltaTime * timespeed;
		}
		if (month != oldMonth)
		{
			ChangeDay(month);
			oldMonth = month;
		}
	}

	void ChangeDay(int newVal)
	{
		Sprite s1 = digits[newVal % 10], s0 = digits[newVal / 10];
	
		number[0].sprite = s0;
		number[1].sprite = s1;
	}
}
