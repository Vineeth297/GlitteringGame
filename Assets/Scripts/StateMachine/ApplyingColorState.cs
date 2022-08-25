using UnityEngine;

public class ApplyingColorState : PlayerControlBaseState
{
	public override void OnStart()
	{
		Debug.Log("In Coloring Start");
		Player.SelectGlitterLayer();
	}

	public override void OnUpdate()
	{
		
	}

	public override void OnExit()
	{
		
	}
}
