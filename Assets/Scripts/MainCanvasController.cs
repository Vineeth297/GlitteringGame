using System;
using DG.Tweening;
using UnityEngine;

public class MainCanvasController : MonoBehaviour
{
	public static MainCanvasController Inst;
	
	private PlayerInputControl _player;
	
	[SerializeField] private GameObject glitteringMenu;
	[SerializeField] private GameObject glueMenu;
	[SerializeField] private GameObject coloringMenu;
	[SerializeField] private GameObject blowingMenu;

	[SerializeField] private float slideDownTime = 1f;
	[SerializeField] private float slideDownDistancInY = 1f;

	private void Awake()
	{
		#region Singleton
		
		if (Inst)
			Destroy(gameObject);
		else
			Inst = this;
		
	#endregion
	}

	private void Start()
	{
		_player = GetComponent<PlayerInputControl>();
		SlideUpTheMenu();
	}
	
	public void SelectGlue()
	{
		_player.SwitchToState(InputState.GluingState);
		SlideDownTheMenu();
	}
	
	public void SelectColor()
	{
		_player.SwitchToState(InputState.ColorState);
		SlideDownTheMenu();
	}
	
	public void SelectBlower()
	{
		_player.SwitchToState(InputState.BlowingState);
		SlideDownTheMenu();
	}

	public void SlideUpTheMenu()
	{
		glitteringMenu.GetComponent<RectTransform>().DOAnchorPosY(181, slideDownTime);
	}
	
	public void SlideDownTheMenu()
	{
		glitteringMenu.GetComponent<RectTransform>().DOAnchorPosY(slideDownDistancInY, slideDownTime);
	}

	public void ShowGluePanel()
	{
		glueMenu.SetActive(true);
	}
	
	public void ShowColoringPanel()
	{
		glueMenu.SetActive(false);
		coloringMenu.SetActive(true);
	}
	
	public void ShowBlowingPanel()
	{
		glueMenu.SetActive(false);
		coloringMenu.SetActive(false);
		blowingMenu.SetActive(true);
	}
}
