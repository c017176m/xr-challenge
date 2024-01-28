using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	private Vector2 
		MoveForce;

	private bool 
		isJump, 
		isSprint;

	private float 
		MouseX;

	[SerializeField] private float 
		MoveMultiplier,
		MoveSpeedCap,
		TurnMultiplier,
		DistanceOfGroundRaycast;

	private Rigidbody 
		RB;

	[Header("Requires Manual Connections via Heirarchy")]
	[SerializeField] private Camera 
		MainCamera;

	private void Awake()
	{
		RB = GetComponent<Rigidbody>();
		MoveMultiplier = 10.0f;
		MoveSpeedCap = 3.0f;
		TurnMultiplier = 50.0f;
	}

	private void Start()
	{
		if (MainCamera == null) { return; }
	}

	public void UpdateMovement(string actionName, dynamic inputData)
	{
		switch (actionName)
		{
			case "Jump":
				if (inputData == 1)
					isJump = true;
				else
					isJump = false;
				break;

			case "Sprint":
				if (inputData == 1)
					isSprint = true;
				else
					isSprint = false;
				break;

			case "Walk":
				MoveForce = inputData;
				break;

			case "HorizontalCamRotation":
				MouseX = inputData;
				break;

			default:
				Debug.Log("No valid input type");
				break;

		}
	}

	private void FixedUpdate()
	{
		if (isJump && Physics.Raycast(transform.position, Vector3.down, DistanceOfGroundRaycast))
		{
			isJump = false;
			RB.velocity = Vector3.up * 10;
		}

		transform.Rotate(Vector3.up * Time.fixedDeltaTime * MoveForce.x * TurnMultiplier);

		if (isSprint)
		{
			Vector3 force = (transform.forward * MoveForce.y) * MoveMultiplier * 2;
			RB.AddForce(force * (1f - (RB.velocity.magnitude / MoveSpeedCap)), ForceMode.Force);
		}
		else
		{
			Vector3 force = (transform.forward * MoveForce.y) * MoveMultiplier;
			RB.AddForce(force * (1f - (RB.velocity.magnitude / MoveSpeedCap)), ForceMode.Force);
		}
	}
}
