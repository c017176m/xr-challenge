using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
	[Header("Requires Manual Connections via Heirarchy")]
	[SerializeField]
	private GameObject GUI;

	[Header("Automatic Connections")]
	[SerializeField]
	private int GuiChildCount;

	[SerializeField]
	private List<GameObject> GUIStrangers;

	[SerializeField] private GameObject ScoreTextGOTextReference, WinTextGOTextReference, GameScreenGOReference, WinScreenGOReference;

	private void Awake()
	{
		foreach (Transform transformComponent in GUI.transform.GetComponentsInChildren<Transform>(true))
		{
			GUIStrangers.Add(transformComponent.gameObject);
		}
		for (int i = 0; i < GUIStrangers.Count; i++)
		{
			switch (GUIStrangers[i].name.ToString().ToLower())
			{
				case "scoretext":
					ScoreTextGOTextReference = GUIStrangers[i];
					break;
				case "gamescreen":
					GameScreenGOReference = GUIStrangers[i];
					break;
				case "winscreen":
					WinScreenGOReference = GUIStrangers[i];
					break;
				case "winmessagesubtext":
					WinTextGOTextReference = GUIStrangers[i];
					break;
				default:
					break;

			}
		}
	}
	private void Start()
	{
		//Set all GUIs to disabled then GUI most-parent to enabled
		foreach (Transform transformComponent in GUI.transform.GetComponentsInChildren<Transform>(true))
		{
			transformComponent.gameObject.SetActive(false);
		}
		GUI.SetActive(true);

		//Set all game screen objects to enabled
		foreach (Transform transformComponent in GameScreenGOReference.transform.GetComponentsInChildren<Transform>(true))
		{
			transformComponent.gameObject.SetActive(true);
		}
	}

	public void UpdateDisplayScore(int data)
	{
		ScoreTextGOTextReference.GetComponent<TextMeshProUGUI>().text = ($"SCORE: {data} ");
	}

	public void CueFinishDisplay(int finalScore)
	{
		GameScreenGOReference.SetActive(false);

		WinTextGOTextReference.GetComponent<TextMeshProUGUI>().text = ($"final score: {finalScore} ");
		
		//Set all win screen objects to enabled
		foreach (Transform transformComponent in WinScreenGOReference.transform.GetComponentsInChildren<Transform>(true))
		{
			transformComponent.gameObject.SetActive(true);
		}
	}
}
