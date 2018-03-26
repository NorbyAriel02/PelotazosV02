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

public class MovePlayer : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {
	public Rigidbody2D rbPlayer;
	public float speed;
    public AxisOption axis = AxisOption.Both;
	public Image JoystickContainer;
	public Image Joystick;
    public Vector2 InputDirection { set; get; }
    public Vector3 startPos;
    public int MovementRange = 100;

    void Update()
    {
        if(InputDirection.magnitude == 0 && rbPlayer.velocity.magnitude > 0)
            rbPlayer.velocity -= (rbPlayer.velocity / 10);
        else
            MovePLayer(InputDirection);
    }
	
	private void MovePLayer(Vector2 Movement)
	{        
		if (Movement.magnitude != 0) 
		{
			rbPlayer.velocity = Movement * speed;	
		} 
	}

	public virtual void OnPointerUp(PointerEventData data)
	{
		InputDirection = Vector2.zero;		
        Joystick.rectTransform.anchoredPosition = InputDirection;
    }

	public virtual void OnPointerDown(PointerEventData data)
	{
        
    }

	public virtual void OnDrag(PointerEventData data)
	{        
        Vector2 pos = Vector2.zero;
        InputDirection = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
			    JoystickContainer.rectTransform,
			    data.position,
			    data.pressEventCamera,
			    out pos)) {

            if (axis == AxisOption.OnlyHorizontal)
                InputDirection = new Vector2(data.delta.x, 0);
            else if (axis == AxisOption.OnlyVertical)
                InputDirection = new Vector2(0, data.delta.y);
            else
                InputDirection = data.delta;

            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

			Joystick.rectTransform.anchoredPosition = (20 * InputDirection);			
		}
    }
}
