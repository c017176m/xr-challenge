using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
	[SerializeField]
	private int matchScore;

	public Pickup[] pickups = null;

	public delegate void Delegate_UpdateScoreDisplay(int scoreToDisplay);
	public static event Delegate_UpdateScoreDisplay Event_UpdateScoreDisplay;

	private void Start()
	{
		matchScore = 0;
	}

	public void UpdateScore(int scoreGained)
	{
		matchScore += scoreGained;
		Event_UpdateScoreDisplay(matchScore);
	}

	public void CueFinish()
	{
		int collectedCount = 0;
		for (int i = 0; i < pickups.Length; i++)
		{
			Debug.Log(pickups[i] + " " + pickups[i].IsCollected + " " + i);
			if (pickups[i].IsCollected == false) { continue; }
			collectedCount++;

		}
		if (collectedCount >= pickups.Length)
		{
			Debug.Log("Win");
		}
	}


}
