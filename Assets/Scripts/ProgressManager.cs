using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
	[SerializeField]
	private int matchScore;

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
}
