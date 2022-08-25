using UnityEngine;

public class MainCanvasController : MonoBehaviour
{
	private PlayerInputControl _player;

	private void Start()
	{
		_player = GetComponent<PlayerInputControl>();
	}
	
	public void SelectGlue()
	{
		_player.SwitchToState(InputState.GluingState);
	}
	
	public void SelectColor()
	{
		_player.SwitchToState(InputState.ColorState);
	}
	
	public void SelectBlower()
	{
		_player.SwitchToState(InputState.BlowingState);
	}
}
