using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpecularLight : MonoBehaviour
{
	[SerializeField] private GameObject movingLight;
	[SerializeField] private Transform startTransform;
	[SerializeField] private Transform endTransform;

	[SerializeField] private float moveDuration;
	
	private void Start()
	{
		movingLight.transform.position = startTransform.position;

		Sequence mySequence = DOTween.Sequence();
		mySequence.Append(movingLight.transform.DOMove(endTransform.position, moveDuration));
		mySequence.Append(movingLight.transform.DOMove(startTransform.position, moveDuration));
		mySequence.SetLoops(-1);
	}
}
