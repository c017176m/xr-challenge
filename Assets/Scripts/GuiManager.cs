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
	private List<Transform> GUIChildren;

	private void Start()
	{
		GuiChildCount = GUI.transform.childCount;
		for (int i = 0; i < GuiChildCount; i++)
		{
			GUIChildren.Add(GUI.transform.GetChild(i));
		}
	}

	void UpdateDisplayScore(int data)
	{
		Transform ScoreTextGOReference = GUIChildren.FirstOrDefault(obj => obj.name == "ScoreText");
		ScoreTextGOReference.gameObject.GetComponent<TextMeshProUGUI>().text = ("SCORE: " + data.ToString());
	}
}
