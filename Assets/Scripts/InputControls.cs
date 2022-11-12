using UnityEngine;

public class InputControls : MonoBehaviour
{
	private Controls controls;
	
	public Vector2 LeftAxisInput {get; private set;}
	public Vector2 RightAxisInput {get; private set;}

	public bool LeftAction {get; private set;}
	public bool RightAction {get; private set;}
	
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		controls = new Controls();
	}

	private void Update() {
		RightAxisInput = controls.Generic.RightAxis.ReadValue<Vector2>();
		LeftAxisInput = controls.Generic.LeftAxis.ReadValue<Vector2>();
		RightAction = controls.Generic.RightAction.ReadValue<bool>();
		LeftAction = controls.Generic.LeftAction.ReadValue<bool>();
	}
	
}
