using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	[Header("Requires Manual Connections via Heirarchy")]
	[SerializeField] 
	private GameObject PlayerGO;

	[SerializeField]
	private GameObject ProgressManagerGO;

	[SerializeField]
	private GameObject GuiManagerGO;

	[Header("Automatic Connections")]
	[SerializeField]
	private PlayerMovement Script_PlayerMovement;

	[SerializeField]
	private ProgressManager Script_ProgressManager;

	[SerializeField]
	private GuiManager Script_GuiManager;


	//Connect senders and receivers
	private void Awake()
	{
		InputManager.Event_RecognisedInput += RecognisedInput_Response;
		PlayerCollisions.Event_TriggerEnter += TriggerEnter_Response;
		ProgressManager.Event_UpdateScoreDisplay += UpdateScoreDisplay_Response;
	}

	private void Start()
	{
		Script_PlayerMovement = PlayerGO.GetComponent<PlayerMovement>();
		Script_ProgressManager = ProgressManagerGO.GetComponent<ProgressManager>();
		Script_GuiManager = GuiManagerGO.GetComponent<GuiManager>();

	}

	//Disconnect senders and recievers
	private void OnApplicationQuit()
	{
		InputManager.Event_RecognisedInput -= RecognisedInput_Response;
		PlayerCollisions.Event_TriggerEnter -= TriggerEnter_Response;
		ProgressManager.Event_UpdateScoreDisplay -= UpdateScoreDisplay_Response;
	}

	void RecognisedInput_Response(string actionName, dynamic inputData)
	{
		Script_PlayerMovement.UpdateMovement(actionName, inputData);
	}

	void TriggerEnter_Response(GameObject responsibleGO, GameObject impactedGO, PlayerCollisions.TagTypes enumOfTag)
	{
		switch (enumOfTag)
		{
			case PlayerCollisions.TagTypes.Pickup:
				int carriedScore = impactedGO.GetComponent<Pickup>().GetPickedUp();
				Script_ProgressManager.UpdateScore(carriedScore);
				break;
			case PlayerCollisions.TagTypes.Finish:
				Script_ProgressManager.CueFinish();
				break;
			default:
				Debug.LogWarning("TriggerEnter_Response has heard an event with no valid TagType included");
				break;
		}
	}

	void UpdateScoreDisplay_Response(int scoreToDisplay)
	{
		Script_GuiManager.UpdateDisplayScore(scoreToDisplay);
	}
}
