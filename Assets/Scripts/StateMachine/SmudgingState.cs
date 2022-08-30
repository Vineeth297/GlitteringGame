using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmudgingState : PlayerControlBaseState
{
	private Camera _camera;
	
	public override void OnStart()
	{
		_camera = Camera.main;
		
		Player.SelectGlueLayer();
	}

	public override void OnUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var ray = _camera.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray.origin, ray.direction, out var hit, 50)) return;
			MainCanvasController.Inst.SpawnGlueDrop(hit.point);
		}

	}

	public override void OnExit()
	{
		
	}
}
