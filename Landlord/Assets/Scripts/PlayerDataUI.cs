using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataUI : MonoBehaviour
{
	public Text balance;
	public Text reputation;
	public Text propertyCnt;
	public Text renterCnt;

	private void FixedUpdate()
	{
		balance.text = Utils.HandleMoney(GameManager.instance.balance);
		reputation.text = GameManager.instance.reputation.ToString() + "%";
		propertyCnt.text = GameManager.instance.apartments.Count.ToString();
		renterCnt.text = GameManager.instance.renterNum.ToString();
	}
}