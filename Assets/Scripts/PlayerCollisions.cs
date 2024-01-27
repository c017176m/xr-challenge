using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
	//public delegate void Delegate_TriggerEnter(GameObject responsibleGO, GameObject impactedGO);
	internal delegate void Delegate_TriggerEnter(GameObject responsibleGO, GameObject impactedGO, TagTypes enumOfTag);
	internal static event Delegate_TriggerEnter Event_TriggerEnter;

	//An enum where we can add expected collision types
    internal enum TagTypes
    {
		Pickup,
        Finish,
		Unknown
    }

    private void OnTriggerEnter(Collider other)
	{
		Debug.Log($"Object hit! is {other.gameObject.tag} ");

		//Let's first see if there's a tag on the other object
		switch (other.gameObject.tag)
		{

			/* Switch used for future expandability, 
			 * cases check the 'String' on the tag */
			case "Pickup":

				/* Using isCollected to allow for a possible regenerative pickup 
				 * gameObject (i.e. not all pickups may be permanently off once 
				 * picked up) */
				if (other.gameObject.GetComponent<Pickup>().IsCollected == false)
				{

					// Just so I'm told about it :)
					Debug.Log("Hit a Pickup!");

					/* Now just broadcast the enum of the type of collision which 
					 * just happened and some cause/effect data */
					Event_TriggerEnter(gameObject, other.gameObject, TagTypes.Pickup);
					break;
				}
				break;

			case "Finish":
				Debug.Log("Hit a Finish!");
				Event_TriggerEnter(gameObject, other.gameObject, TagTypes.Finish);
				break;

			default:
				Debug.LogWarning($"No tag associated with gameObject: {other.gameObject} ");
				break;
		}
	}
}
