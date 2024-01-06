using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
	public delegate void Delegate_TriggerEnter(GameObject responsibleGO, GameObject impactedGO);
	public delegate void Delegate_TriggerEnter(GameObject responsibleGO, GameObject impactedGO, TagTypes enumOfTag);
	public static event Delegate_TriggerEnter Event_TriggerEnter;

    public enum TagTypes
    {
		Pickup,
        Finish
    }

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
					Event_TriggerEnter(gameObject, other.gameObject, TagTypes.Pickup);
					break;
				}
				break;
			case "Finish":
				Debug.Log("Hit a Finish!");
				Event_TriggerEnter(gameObject, other.gameObject);
				break;
		}
	}
}
