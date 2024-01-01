using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
	public delegate void Delegate_TriggerEnter(GameObject responsibleGO, GameObject impactedGO);
	public static event Delegate_TriggerEnter Event_TriggerEnter;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Object hit! is " + other.gameObject.tag);
		switch (other.gameObject.tag)
		{
			case "Pickup":
				if (other.gameObject.GetComponent<Pickup>().IsCollected == false)
				{
					Debug.Log("Hit a Pickup!");
					Event_TriggerEnter(gameObject, other.gameObject);
					break;
				}
				break;
		}
	}
}
