using System;

public class QuickSort
{
	private static void quickSort(int[] arr, int lower, int upper)
	{
		if (upper <= lower)
		{
			return;
		}
		int pivot = arr[lower];
		int start = lower;
		int stop = upper;

		while (lower < upper)
		{
			while (arr[lower] <= pivot && lower < upper)
			{
				lower++;
			}
			while (arr[upper] > pivot && lower <= upper)
			{
				upper--;
			}
			if (lower < upper)
			{
				swap(arr, upper, lower);
			}
		}
		swap(arr, upper, start); // upper is the pivot position
		quickSort(arr, start, upper - 1); // pivot -1 is the upper for left sub array.
		quickSort(arr, upper + 1, stop); // pivot + 1 is the lower for right sub array
	}

	public static void sort(int[] arr)
	{
		int size = arr.Length;
		quickSort(arr, 0, size - 1);
	}

	private static void swap(int[] arr, int first, int second)
	{
		int temp = arr[first];
		arr[first] = arr[second];
		arr[second] = temp;
	}

	public static void Main(string[] args)
	{
		int[] array = new int[] { 3, 4, 2, 1, 6, 5, 7, 8, 1, 1 };
		QuickSort.sort(array);
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");
		}
	}
}