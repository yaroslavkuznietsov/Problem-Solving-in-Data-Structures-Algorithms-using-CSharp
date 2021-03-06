using System;

public class BucketSort
{

	public static void sort(int[] array, int lowerRange, int upperRange)
	{
		int i, j;
		int size = array.Length;
		int range = upperRange - lowerRange;
		int[] count = new int[range];

		for (i = 0; i < size; i++)
		{
			count[array[i] - lowerRange]++;
		}

		j = 0;
		for (i = 0; i < range; i++)
		{
			for (; count[i] > 0; (count[i])--)
			{
				array[j++] = i + lowerRange;
			}
		}
	}

	public static void Main(string[] args)
	{
		int[] array = new int[] { 23, 24, 22, 21, 26, 25, 27, 28, 21, 21 };
		BucketSort.sort(array, 20, 30);
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");
		}
	}
}