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
	public static PlayerInputControl Instance;
	
	private PlayerControlBaseState currentState;

	protected WaitingForInputState WaitingForInputState = new WaitingForInputState();
	protected ApplyingGlueState ApplyingGlueState = new ApplyingGlueState();
	protected ApplyingColorState ApplyingColorState = new ApplyingColorState();
	protected BlowingState BlowingState = new BlowingState();

	[SerializeField] private GameObject glueLayerObject;
	[SerializeField] private GameObject glitterLayerObject;

	private void Awake()
	{
		Instance = this;
	}
	
    private void Start()
	{
		currentState = WaitingForInputState;

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
			InputState.BlowingState => ApplyingColorState,
			_ => throw new ArgumentOutOfRangeException(nameof(inputState), inputState, null)
		};
		currentState.OnStart();
	}

	public void SelectGlueLayer()
	{
		glueLayerObject.SetActive(true);
	}

	public void SelectGlitterLayer()
	{
		glitterLayerObject.SetActive(true);
	}
	
}
