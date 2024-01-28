using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
	[Header("Requires Manual Connections via Heirarchy")]
	[SerializeField] private GameObject
		GUI;

	[Header("Automatic Connections")]
	[SerializeField] private int
		GuiChildCount;

	[SerializeField] private List<GameObject>
		GUIStrangers;

	[SerializeField] private GameObject
		ScoreTextGOTextReference, 
		WinTextGOTextReference, 
		GameScreenGOReference, 
		WinScreenGOReference;

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
		GuiChildCount = GUI.transform.childCount;
		for (int i = 0; i < GuiChildCount; i++)
		{
			GUIChildren.Add(GUI.transform.GetChild(i));
		}
		ScoreTextGOTextReference = GUIChildren.FirstOrDefault(obj => obj.name == "ScoreText");
	}

	public void UpdateDisplayScore(int data)
	{
		ScoreTextGOTextReference.gameObject.GetComponent<TextMeshProUGUI>().text = ("SCORE: " + data.ToString());
	}
}
