﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
	public Sprite tabIdle;
	public Sprite tabHover;
	public Sprite tabActive;
	public TabButton selectedTab;
	public List<GameObject> objectsToSwap;
	public List<GameObject> buyButtons;
	public void Start()
	{
		ResetTabs();
	}
	public void Subscribe(TabButton button)
	{
		if(tabButtons == null)
		{
			tabButtons = new List<TabButton>();
		}

		tabButtons.Add(button);
	}
	public void OnTabEnter(TabButton button)
	{
		ResetTabs();
		if(selectedTab == null || button != selectedTab)
		{
			button.background.sprite = tabHover;
		}
	}
	public void OnTabExit(TabButton button)
	{
		ResetTabs();
	}
	public void OnTabSelected(TabButton button)
	{
		if(selectedTab != null)
		{
			selectedTab.Deselect();
		}
		selectedTab = button;
		selectedTab.Select();
		ResetTabs();
		button.background.sprite = tabActive;
		button.background.color = button.ActiveColor;
		int index = button.transform.GetSiblingIndex();
		for (int i = 0; i < objectsToSwap.Count; i++)
		{
			if (i == index)
			{
				objectsToSwap[i].SetActive(true);
			}
			else
			{
				objectsToSwap[i].SetActive(false);
				buyButtons[i].SetActive(false);
			}
		}
	}
	public void ResetTabs()
	{
		foreach(TabButton button in tabButtons)
		{
			if(selectedTab != null && button == selectedTab)
			{
				button.background.color = button.ActiveColor;
				continue;
			}
			button.background.sprite = tabIdle;
			button.background.color = button.IdleColor;
		}
	}
}
