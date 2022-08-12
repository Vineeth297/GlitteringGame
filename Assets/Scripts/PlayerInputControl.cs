using System;
using UnityEngine;

public enum InputState
{
	WaitingState,
	GluingState,
	ColorState,
	BlowingState
}
public class PlayerInputControl : MonoBehaviour
{
	
	private static PlayerControlBaseState _currentState;

	private static readonly WaitingForInputState WaitingForInputState = new WaitingForInputState();
	private static readonly ApplyingGlueState ApplyingGlueState = new ApplyingGlueState();
	private static readonly ApplyingColorState ApplyingColorState = new ApplyingColorState();
	private static readonly BlowingState BlowingState = new BlowingState();
	
    private void Start()
	{
		_currentState = WaitingForInputState;

		_currentState.OnStart();
	}

	public static void SwitchToState(InputState inputState)
	{
		_currentState.OnExit();
		_currentState = inputState switch
		{
			InputState.WaitingState => WaitingForInputState,
			InputState.GluingState => ApplyingGlueState,
			InputState.ColorState => ApplyingColorState,
			InputState.BlowingState => ApplyingColorState,
			_ => throw new ArgumentOutOfRangeException(nameof(inputState), inputState, null)
		};
		_currentState.OnStart();
	}

}
