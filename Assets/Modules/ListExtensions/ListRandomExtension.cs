using UnityEngine;
using System.Collections.Generic;
public static class ListRandomExtension {
    public static T RetrieveRandom<T>(this List<T> list)
    { return (list[Random.Range(0, list.Count)]); } 
}
