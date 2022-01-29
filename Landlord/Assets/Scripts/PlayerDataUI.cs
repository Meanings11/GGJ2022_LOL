using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
	public class PlayerDataUI : MonoBehaviour
	{
		public Text balance;
		public Text reputation;
		public Text propertyCnt;
		public Text renterCnt;

		private void FixedUpdate()
		{
			balance.text = PlayerStats.balance.ToString();
			reputation.text = PlayerStats.reputation.ToString();
			propertyCnt.text = PlayerStats.apartments.Length.ToString();
			renterCnt.text = PlayerStats.renters.Length.ToString();
		}
	}
}