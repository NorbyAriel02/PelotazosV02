using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum AxisOption
{ 
    Both, // Use both
    OnlyHorizontal, // Only horizontal
    OnlyVertical // Only vertical
}
[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour {

	// PUBLIC
	public SimpleTouchController rightController;
	public float speedMovements = 5f;
	public float speedContinuousLook = 100f;
	public float speedProgressiveLook = 3000f;
	public bool continuousRightController = true;

	// PRIVATE
	private Rigidbody2D _rigidbody;
	private Vector2 prevRightTouchPos;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		rightController.TouchEvent += RightController_TouchEvent;
		rightController.TouchStateEvent += RightController_TouchStateEvent;
	}

	public bool ContinuousRightController
	{
		set{continuousRightController = value;}
	}

	void RightController_TouchStateEvent (bool touchPresent)
	{
		if(!continuousRightController)
		{
			prevRightTouchPos = Vector2.zero;
		}
	}

	void RightController_TouchEvent (Vector2 value)
	{		
		if(!continuousRightController)
		{
			_rigidbody.MovePosition(transform.position + (transform.up * rightController.GetTouchPosition.y * Time.deltaTime * speedMovements) +
				(transform.right * rightController.GetTouchPosition.x * Time.deltaTime * speedMovements) );
		}
	}

	void Update()
	{

	}

	void OnDestroy()
	{
		rightController.TouchEvent -= RightController_TouchEvent;
		rightController.TouchStateEvent -= RightController_TouchStateEvent;
	}
}
