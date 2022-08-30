using UnityEngine;

public class ApplyingGlueState : PlayerControlBaseState
{
	private Camera _camera;
	public override void OnStart()
	{
		Debug.Log("In Glue Start");
		_camera = Camera.main;
		//Player.SelectGlueLayer();
		//spawn glue drops only on dress part
	}

	public override void OnUpdate()
	{
		Debug.Log("InGlueUpdate");

		if (!Input.GetMouseButtonDown(0)) return;
		
		var ray = _camera.ScreenPointToRay(Input.mousePosition);
		if (!Physics.Raycast(ray.origin, ray.direction, out var hit, 50)) return;
		MainCanvasController.Inst.SpawnGlueDrop(hit.point);
		//if (!hit.transform.CompareTag("EraseTarget")) return;
	}

	public override void OnExit()
	{
		//Player.SwitchToState(InputState.SmudgingState);
	}
}
