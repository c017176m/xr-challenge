using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	[Header("Requires Manual Connections via Heirarchy")]
	[SerializeField] 
	private GameObject PlayerGO;

	[SerializeField]
	private GameObject ProgressManagerGO;

	[Header("Automatic Connections")]
	[SerializeField]
	private PlayerMovement Script_PlayerMovement;

	[SerializeField]
	private ProgressManager Script_ProgressManager;


	//Connect senders and receivers
	private void Awake()
	{
		InputManager.Event_RecognisedInput += RecognisedInput_Response;
		PlayerCollisions.Event_TriggerEnter += TriggerEnter_Response;
	}

	private void Start()
	{
		Script_PlayerMovement = PlayerGO.GetComponent<PlayerMovement>();
		Script_ProgressManager = ProgressManagerGO.GetComponent<ProgressManager>();
	}

	//Disconnect senders and recievers
	private void OnApplicationQuit()
	{
		InputManager.Event_RecognisedInput -= RecognisedInput_Response;
		PlayerCollisions.Event_TriggerEnter -= TriggerEnter_Response;
	}



	void RecognisedInput_Response(string actionName, dynamic inputData)
	{
		Script_PlayerMovement.UpdateMovement(actionName, inputData);
	}

	void TriggerEnter_Response(GameObject responsibleGO, GameObject impactedGO)
	{
		int carriedScore = impactedGO.GetComponent<Pickup>().GetPickedUp();
		Script_ProgressManager.UpdateScore(carriedScore);
	}
}
