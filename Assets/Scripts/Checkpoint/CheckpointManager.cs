using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;

public class CheckpointManager : Singleton<CheckpointManager>
{
	public int lastCheckPointKey = 0;

	public List<CheckpointBase> checkpoints;

	public bool HasCheckpoint()
	{
		return lastCheckPointKey > 0;
	}

	public void SaveCheckPoint(int i)
	{
		if(i > lastCheckPointKey)
		{
			lastCheckPointKey = i;
		}
	}

	public Vector3 GetPositionFromLastCheckpoint()
	{
		var checkpoint = checkpoints.Find(i => i.key == lastCheckPointKey);
		return checkpoint.transform.position;
	}

	private void Start()
	{
		LoadFromSave();
	}

	private void LoadFromSave()
	{
		var number = SaveManager.Instance.Setup.checkpointNumber;
		for(int i = 0; i < checkpoints.Count; ++i)
		{
			if(checkpoints[i].key <= number)
			{
				checkpoints[i].TurnItOn();
				checkpoints[i].GetComponent<CheckpointSaver>().CheckAsSaved();
			}
			if(checkpoints[i].key == number)
			{
				Player.Instance.characterController.enabled = false;
				Player.Instance.transform.position = checkpoints[i].transform.position;
				Player.Instance.characterController.enabled = true;
			}
		}
	}
}
