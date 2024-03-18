using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;
using TMPro;

public class PlayLevel : MonoBehaviour
{
	public TextMeshProUGUI uiTextName;

	private void Start()
	{
		SaveManager.Instance.FileLoaded += OnLoad;
	}

	public void OnLoad(SaveManager.SaveSetup setup)
	{
		Debug.Log("Dados carregados: Último nível: " + setup.lastLevel + ", Nome do jogador: " + setup.playerName);
		uiTextName.text = "Play " + (setup.lastLevel + 1);
	}

	private void OnDestroy()
	{
		SaveManager.Instance.FileLoaded -= OnLoad;
	}
}
