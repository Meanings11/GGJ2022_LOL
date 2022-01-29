using System;
using UnityEngine;
using UnityEngine.UI;

public class CalenderTimer : MonoBehaviour
{
	public Image[] number;
	public Sprite[] digits;
	public int day = 1;

	private int oldDay = 1;

	private void Start()
	{
		ChangeDay(day);
		oldDay = day;
	}

	private void FixedUpdate()
	{
		if (day != oldDay)
		{
			ChangeDay(day);
			oldDay = day;
		}
	}

	void ChangeDay(int newVal)
	{
		Sprite s1 = digits[newVal % 10], s0 = digits[newVal / 10];
	
		number[0].sprite = s0;
		number[1].sprite = s1;
	}
}
