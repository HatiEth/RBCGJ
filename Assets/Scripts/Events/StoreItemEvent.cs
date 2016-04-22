using UnityEngine;
using System.Collections;

public class StoreItemEvent {
	public delegate void StoreItemAction(IItem item);
	public static event StoreItemAction OnStoreItem;

	public static void Send(IItem item)
	{
		if (OnStoreItem != null) OnStoreItem(item);
	}
}
