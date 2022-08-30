using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private Camera _camera;

	[SerializeField] private Transform drawing;
	[SerializeField] private Transform camInitialTransform;
	[SerializeField] private Transform camFinalTransform;
	private void Start()
	{
		_camera = Camera.main;
		
		_camera.transform.DOMove(camFinalTransform.position, 3f);
		_camera.transform.DORotate(Vector3.right * 90f, 3.25f).SetEase(Ease.Linear);
	}
	
	
}
