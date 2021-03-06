using System;

public class Algo
{
	public int bruteForceSearch(string text, string pattern)
	{
		return bruteForceSearch(text.ToCharArray(), pattern.ToCharArray());
	}

	private int bruteForceSearch(char[] text, char[] pattern)
	{
		int i = 0, j = 0;
		int n = text.Length;
		int m = pattern.Length;

		while (i <= n - m)
		{
			j = 0;
			while (j < m && pattern[j] == text[i + j])
			{
				j++;
			}
			if (j == m)
			{
				return (i);
			}
			i++;
		}
		return -1;
	}

	public int robinKarp(string text, string pattern)
	{
		return robinKarp(text.ToCharArray(), pattern.ToCharArray());
	}

	private int robinKarp(char[] text, char[] pattern)
	{
		int n = text.Length;
		int m = pattern.Length;
		int i, j;
		int prime = 101;
		int powm = 1;
		int TextHash = 0, PatternHash = 0;
		if (m == 0 || m > n)
		{
			return -1;
		}

		for (i = 0; i < m - 1; i++)
		{
			powm = (powm << 1) % prime;
		}

		for (i = 0; i < m; i++)
		{
			PatternHash = ((PatternHash << 1) + pattern[i]) % prime;
			TextHash = ((TextHash << 1) + text[i]) % prime;
		}

		for (i = 0; i <= (n - m); i++)
		{
			if (TextHash == PatternHash)
			{
				for (j = 0; j < m; j++)
				{
					if (text[i + j] != pattern[j])
					{
						break;
					}
				}
				if (j == m)
				{
					return i;
				}
			}
			TextHash = (((TextHash - text[i] * powm) << 1) + text[i + m]) % prime;
			if (TextHash < 0)
			{
				TextHash = (TextHash + prime);
			}
		}
		return -1;
	}

	private void KMPPreprocess(char[] pattern, int[] ShiftArr)
	{
		int m = pattern.Length;
		int i = 0, j = -1;
		ShiftArr[i] = -1;
		while (i < m)
		{
			while (j >= 0 && pattern[i] != pattern[j])
			{
				j = ShiftArr[j];
			}
			i++;
			j++;
			ShiftArr[i] = j;
		}
	}

	public int KMP(string text, string pattern)
	{
		return KMP(text.ToCharArray(), pattern.ToCharArray());
	}

	private int KMP(char[] text, char[] pattern)
	{
		int i = 0, j = 0;
		int n = text.Length;
		int m = pattern.Length;
		int[] ShiftArr = new int[m + 1];
		KMPPreprocess(pattern, ShiftArr);

		while (i < n)
		{
			while (j >= 0 && text[i] != pattern[j])
			{
				j = ShiftArr[j];
			}
			i++;
			j++;
			if (j == m)
			{
				return (i - m);
			}
		}
		return -1;
	}

	public int KMPFindCount(char[] text, char[] pattern)
	{
		int i = 0, j = 0, count = 0;
		int n = text.Length;
		int m = pattern.Length;
		int[] ShiftArr = new int[m + 1];
		KMPPreprocess(pattern, ShiftArr);

		while (i < n)
		{
			while (j >= 0 && text[i] != pattern[j])
			{
				j = ShiftArr[j];
			}
			i++;
			j++;
			if (j == m)
			{
				count++;
				j = ShiftArr[j];
			}
		}
		return count;
	}

	public static void Main(string[] args)
	{
		string st1 = "hello, world!";
		string st2 = "world";
		Algo algo = new Algo();
		Console.WriteLine("BruteForceSearch return : " + algo.bruteForceSearch(st1, st2));
		Console.WriteLine("RobinKarp return : " + algo.robinKarp(st1, st2));
		Console.WriteLine("KMP return : " + algo.KMP(st1, st2));
	}
}