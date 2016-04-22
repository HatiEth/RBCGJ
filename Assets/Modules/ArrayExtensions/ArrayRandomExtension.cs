using UnityEngine;
public static class ArrayRandomExtension {
	public static T RetrieveRandom<T>(this T[] array) {
		return (array[Random.Range(0, array.Length)]);
	}
}
