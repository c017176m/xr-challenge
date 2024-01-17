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
		for (int i = 0; i < pickups.Length; i++)
		{
			if (pickups[i].IsCollected == false) { break; }
			Debug.Log("If you see this you got all pickups and hit the finish!");
		}
	}


}
