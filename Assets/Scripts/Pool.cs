using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool : MonoBehaviour
{
	public GameObject ItemPrefab;

	List<GameObject> pool;

	public void Initialize (int count)
	{
		if (pool == null)
			pool = new List<GameObject> ();
		else 
		{
			Debug.LogError ("You tried initialize pool second time!");
			return;
		}
			
		for (int i = 0; i < count; i++) {
			InstantiateObj ();
		}
	}

	public GameObject Pull ()
	{
		if (pool.Count == 0) {
			InstantiateObj ();
		}

		GameObject obj = pool [0];
		pool.Remove (obj);

		return obj;
	}

	public void Push (GameObject obj)
	{
		pool.Add (obj);
		obj.transform.SetParent (transform);
		obj.transform.localPosition = Vector3.zero;
	}

	private void InstantiateObj ()
	{
		GameObject obj = Instantiate (ItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		obj.transform.SetParent (transform);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one;
		pool.Add (obj);
	}
}
