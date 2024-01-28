using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
	internal delegate void Delegate_TriggerEnter(GameObject responsibleGO, GameObject impactedGO, TagTypes enumOfTag);
	internal static event Delegate_TriggerEnter Event_TriggerEnter;
	internal static event Delegate_TriggerEnter Event_TriggerEnter;
	//An enum to add expected collision types
    internal enum TagTypes
    {
		Pickup,
        Finish,
		Unknown
    }

    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    }

    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
	internal static event Delegate_TriggerEnter Event_TriggerEnter;
	internal static event Delegate_TriggerEnter Event_TriggerEnter;
	internal static event Delegate_TriggerEnter Event_TriggerEnter;
	internal static event Delegate_TriggerEnter Event_TriggerEnter;
	internal static event Delegate_TriggerEnter Event_TriggerEnter;
	//An enum where we can add expected collision types
    internal enum TagTypes
    {
		Pickup,
        Finish,
		Unknown
    }

    private void OnTriggerEnter(Collider other)
		Pickup,
        Finish,
		Unknown
    }

    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
	//An enum to add expected collision types
    internal enum TagTypes
    {
		Pickup,
        Finish,
		Unknown
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
					break;
				}
				break;
		}
	}
}
