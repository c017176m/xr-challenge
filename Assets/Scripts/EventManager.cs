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


	//Connect remote senders to(+=) current receivers
	private void Awake()
	{
		InputManager.Event_RecognisedInput += RecognisedInput_Response;
		PlayerCollisions.Event_TriggerEnter += TriggerEnter_Response;
		ProgressManager.Event_UpdateScoreDisplay += UpdateScoreDisplay_Response;
		ProgressManager.Event_TriggerEndRound += TriggerEndRound_Response;
	}

	/* Getting script references here, since it saves 
	 * having to constantly reference on the spot. Readability. */
	private void Start()
	{
		Script_PlayerMovement = PlayerGO.GetComponent<PlayerMovement>();
		Script_ProgressManager = ProgressManagerGO.GetComponent<ProgressManager>();
		Script_GuiManager = GuiManagerGO.GetComponent<GuiManager>();

	}

	/* Disconnect remote senders and current recievers, 
	 * doesn't use OnDisable as this should exist 
	 * throughout the entire game session and
	 * be removed right at the very end. 
	 * Are better approaches possible/is this
	 * a decent way to do this? */
	private void OnApplicationQuit()
	{
		InputManager.Event_RecognisedInput -= RecognisedInput_Response;
		PlayerCollisions.Event_TriggerEnter -= TriggerEnter_Response;
		ProgressManager.Event_UpdateScoreDisplay -= UpdateScoreDisplay_Response;
		ProgressManager.Event_TriggerEndRound -= TriggerEndRound_Response;
	}

	//Function to respond to events from the InputManager class
	void RecognisedInput_Response(string actionName, dynamic inputData)
	{
		Script_PlayerMovement.UpdateMovement(actionName, inputData);
	}

	//Function to respond to events from the PlayerCollisions class with args as those involved
	void TriggerEnter_Response(GameObject responsibleGO, GameObject impactedGO, PlayerCollisions.TagTypes enumOfTag)
	{
		switch (enumOfTag)
		{
			case PlayerCollisions.TagTypes.Pickup:
				int carriedScore = impactedGO.GetComponent<Pickup>().GetPickedUp();
				Script_ProgressManager.UpdateScore(carriedScore);
				break;
			case PlayerCollisions.TagTypes.Finish:
				Script_ProgressManager.CheckEndRound();
				break;
			default:
				Debug.LogWarning("TriggerEnter_Response has heard an event with no valid TagType included");
				break;
		}
	}

	//Function to respond to events from the ProgressManager class
	void UpdateScoreDisplay_Response(int scoreToDisplay)
	{
		Script_GuiManager.UpdateDisplayScore(scoreToDisplay);
	}

	//Function to respond to a successful end round/level trigger calculated by ProgressManager
	void TriggerEndRound_Response(int finalScore)
	{
		Script_GuiManager.CueFinishDisplay(finalScore);
	}
}



