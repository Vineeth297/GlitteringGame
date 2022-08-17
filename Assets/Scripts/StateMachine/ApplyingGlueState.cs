using UnityEngine;

public class ApplyingGlueState : PlayerControlBaseState
{
	public override void OnStart()
	{
		Debug.Log("In Gluing Start");
		PlayerInputControl.Instance.SelectGlueLayer();
	}

	public override void OnUpdate()
	{
		
	}

	public override void OnExit()
	{
		
	}
}
