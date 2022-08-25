using UnityEngine;

public class ApplyingGlueState : PlayerControlBaseState
{
	public override void OnStart()
	{
		Player.SelectGlueLayer();
	}

	public override void OnUpdate()
	{
		
	}

	public override void OnExit()
	{
		
	}
}
