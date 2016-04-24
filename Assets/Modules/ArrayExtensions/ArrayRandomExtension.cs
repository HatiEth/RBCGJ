using UnityEngine;
public static class ArrayRandomExtension {
	public static T RetrieveRandom<T>(this T[] array, int Min=0) {
		return (array[Random.Range(Min, array.Length)]);
	}
}
