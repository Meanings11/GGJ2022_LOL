public static class Utils
{
	public static string HandleMoney(int costVal)
	{
		if (costVal == 0)
		{
			return "0";
		}
		string res = "";
		int cnt = 0;
		while (costVal > 0)
		{
			if (cnt == 3)
			{
				res =  "," + res;
				cnt = 0;
			}
			res = costVal % 10 + res;
			cnt++;
			costVal /= 10;
		}
		return res;
	}
}