using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
	public SFXType sfxType;
	public MeshRenderer meshRenderer;
	public int key = 01;

	private bool checkpointActived = false;
	private string checkpointKey = "checkpointKey";

	private CheckpointUI checkpointUI;

	[Header("Sounds")]
    public AudioSource audioSource;

	private void Start()
	{
		checkpointUI = FindObjectOfType<CheckpointUI>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!checkpointActived && other.transform.tag == "Player")
		{
			CheckCheckpoint();
		}
	}

	private void PlaySFX()
    {
         SFXPool.Instance.Play(sfxType);
    }

	private void CheckCheckpoint()
	{
		PlaySFX();
		TurnItOn();
		SaveCheckpoint();

		checkpointUI.ShowCheckpointMessage();
	}

	[NaughtyAttributes.Button]
	private void TurnItOn()
	{
		meshRenderer.material.SetColor("_EmissionColor", Color.white);
	}

	private void TurnItOff()
	{
		meshRenderer.material.SetColor("_EmissionColor", Color.grey);
	}

	private void SaveCheckpoint()
	{
		/*if(PlayerPrefs.GetInt(checkpointKey, 0) > key)
			PlayerPrefs.SetInt(checkpointKey, key);*/

		CheckpointManager.Instance.SaveCheckPoint(key);

	    checkpointActived = true;
	}
}
