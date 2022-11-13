using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : MonoBehaviour
{
	public static Vector2 LeftAxisInput {get; private set;}
	public static Vector2 RightAxisInput {get; private set;}

	public static bool LeftAction {get; private set;}
	public static bool RightAction {get; private set;}
	
	private void OnLeftAxis(InputValue v) => LeftAxisInput = v.Get<Vector2>();
	private void OnRightAxis(InputValue v) => RightAxisInput = v.Get<Vector2>();
	private void OnLeftAction(InputValue  v) => LeftAction = v.isPressed;
	private void OnRightAction(InputValue  v) => RightAction = v.isPressed;
}
