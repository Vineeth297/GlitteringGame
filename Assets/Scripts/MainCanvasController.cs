using UnityEngine;

public class MainCanvasController : MonoBehaviour
{
	
	public void SelectGlue()
	{
		PlayerInputControl.Instance.SwitchToState(InputState.GluingState);
	}
	
	public void SelectColor()
	{
		PlayerInputControl.Instance.SwitchToState(InputState.ColorState);
	}
	
	public void SelectBlower()
	{
		PlayerInputControl.Instance.SwitchToState(InputState.BlowingState);
	}
}
