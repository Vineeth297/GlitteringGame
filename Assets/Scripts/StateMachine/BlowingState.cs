using UnityEngine;

public class BlowingState : PlayerControlBaseState
{
	public override void OnStart()
	{
		Debug.Log("In Blowing Start");
		Player.backgroundObject.GetComponent<Background>().toBlowTheRest = true;
	}

	public override void OnUpdate()
	{
		
	}

	public override void OnExit()
	{
		
	}
}
