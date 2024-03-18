using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheckpointSaver : MonoBehaviour
{
	public List<GameObject> checkpointGameObjects;

	private bool _checkPoint = false;

	public int checkpointNumber = 1;

	private void Awake()
	{
		checkpointGameObjects.ForEach(i => i.SetActive(false));
	}

	private void OnTriggerEnter(Collider other)
	{
		Player p = other.GetComponent<Player>();

		if (!_checkPoint && p != null)
		{
			ShowCheckpointSaver();
		}
	}

	private void ShowCheckpointSaver()
	{
		_checkPoint = true;
		checkpointGameObjects.ForEach(i => i.SetActive(true));

		foreach(var i in checkpointGameObjects)
		{
			i.SetActive(true);
			i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
			SaveManager.Instance.SaveCheckpointProgress(checkpointNumber);
		}
	}
}
