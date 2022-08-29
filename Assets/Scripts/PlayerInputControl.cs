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
	private PlayerControlBaseState currentState;

	protected WaitingForInputState WaitingForInputState = new WaitingForInputState();
	protected ApplyingGlueState ApplyingGlueState = new ApplyingGlueState();
	protected ApplyingColorState ApplyingColorState = new ApplyingColorState();
	protected BlowingState BlowingState = new BlowingState();

	public GameObject glueLayerObject;
	public GameObject glitterLayerObject;
	public GameObject backgroundObject;

	
	private void Start()
	{
		currentState = WaitingForInputState;

		_ = new PlayerControlBaseState(this);

		currentState.OnStart();
	}

	public void SwitchToState(InputState inputState)
	{
		currentState.OnExit();
		currentState = inputState switch
		{
			InputState.WaitingState => WaitingForInputState,
			InputState.GluingState => ApplyingGlueState,
			InputState.ColorState => ApplyingColorState,
			InputState.BlowingState => BlowingState,
			_ => throw new ArgumentOutOfRangeException(nameof(inputState), inputState, null)
		};
		currentState.OnStart();
	}

	public void SelectGlueLayer()
	{
		glueLayerObject.SetActive(true);
		backgroundObject.SetActive(false);
	}

	public void SelectGlitterLayer()
	{
		glitterLayerObject.SetActive(true);
		EnableBackground();
	}

	private void EnableBackground()
	{
		backgroundObject.SetActive(true);
	}

	public void SwitchToNextState()
	{
		currentState.OnExit();
		if (currentState == WaitingForInputState)
		{
			//currentState = ApplyingGlueState;
			MainCanvasController.Inst.ShowGluePanel();
		}
		else if (currentState == ApplyingGlueState)
		{
			//currentState = ApplyingColorState;
			MainCanvasController.Inst.ShowColoringPanel();
		}
		else if (currentState == ApplyingColorState)
		{
			//currentState = BlowingState;
			MainCanvasController.Inst.ShowBlowingPanel();
		}
		currentState.OnStart();
	}

	

}
