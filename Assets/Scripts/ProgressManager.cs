using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
	[SerializeField]
	private int matchScore;

	[SerializeField]
	private Pickup[] pickups = null;

	internal delegate void Delegate_SingleIntDelegate(int scoreToDisplay);
	internal static event Delegate_SingleIntDelegate Event_UpdateScoreDisplay;
	internal static event Delegate_SingleIntDelegate Event_TriggerEndRound;

	private void Start()
	{
		matchScore = 0;
	}

	public void UpdateScore(int scoreGained)
	{
		matchScore += scoreGained;
		Event_UpdateScoreDisplay(matchScore);
	}

	public void CheckEndRound()
	{
		int collectedCount = 0;
		for (int i = 0; i < pickups.Length; i++)
		{
			if (pickups[i].IsCollected == false) { continue; }
			collectedCount++;

		}

		if (collectedCount >= pickups.Length)
		{
			Event_TriggerEndRound(matchScore);
		}
	}
















}
