﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplay : MonoBehaviour
{
	public Text moneyCount;

    public List<int> prices;
	public List<float> upgratedValues;

	public string prefPowerUpName;
	public string prefForSlider;

    public Image powerUpImage;
	public Text priceText;
	public Slider progressSlider;
	public Button buyButton;

	private int indexCounter;
	private int money;
	private float step;
	private void Awake()
	{
		money = PlayerPrefs.GetInt("Money");
		step = 1f / prices.Count;
	}
	private void Start()
	{
		moneyCount.text = "Money: " + money.ToString();
		indexCounter = PlayerPrefs.GetInt(prefForSlider, 0);
		Change();
	}
	public void Upgrade()
	{
		if (money >= prices[indexCounter])
		{
			PlayerPrefs.SetInt("Money", money - prices[indexCounter]);
			money = PlayerPrefs.GetInt("Money");
			moneyCount.text = "Money: " + money.ToString();

			PlayerPrefs.SetFloat(prefPowerUpName, upgratedValues[indexCounter]);
			indexCounter++;
			PlayerPrefs.SetInt(prefForSlider, indexCounter);

			Change();
		}
	}
	private void Change()
	{
		if (indexCounter == prices.Count)
		{
			progressSlider.value = 1f;
			priceText.text = "Upgrade Completed!";
			buyButton.interactable = false;
		}
		else
		{
			priceText.text = prices[indexCounter].ToString();
			progressSlider.value = step * indexCounter;
		}
	}
	public void Delete()
	{
		PlayerPrefs.DeleteAll();
	}
}
