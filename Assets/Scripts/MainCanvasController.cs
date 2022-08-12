using UnityEngine;

public class MainCanvasController : MonoBehaviour
{
	
	public void SelectGlue()
	{
		PlayerInputControl.SwitchToState(InputState.GluingState);
	}
	
	public void SelectColor()
	{
		PlayerInputControl.SwitchToState(InputState.ColorState);
	}
	
	public void SelectBlower()
	{
		PlayerInputControl.SwitchToState(InputState.BlowingState);
	}
}
