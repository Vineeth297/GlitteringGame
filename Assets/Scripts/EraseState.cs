using System;
using UnityEngine;

namespace StateMachine
{
	public class EraseState : MonoBehaviour
	{
		public EraseTarget eraseMechanic;

		public float raycastDistance = 50f;

		private Camera _camera;

		private void Start()
		{
			_camera = Camera.main;
		}
		
		private void Update()
		{
			Execute();
		}

		public void Execute()
		{
			if(Input.GetMouseButtonUp(0))
			{
				return;
			}

			if (!Input.GetMouseButton(0)) return;
			
			var ray = _camera.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray.origin, ray.direction, out var hit, raycastDistance)) return;
			if (!hit.transform.CompareTag("EraseTarget")) return;

			eraseMechanic.ApplyColorChanges(hit.point);

		}
	}
}