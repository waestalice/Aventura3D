using UnityEngine;
using TMPro;

public class CheckpointUI : MonoBehaviour
{
    public TextMeshProUGUI checkpointText;

    private void Start()
    {
        checkpointText.gameObject.SetActive(false);
    }

    public void ShowCheckpointMessage()
    {
        checkpointText.gameObject.SetActive(true);
        Invoke("HideCheckpointMessage", 2f);
    }

    private void HideCheckpointMessage()
    {
        checkpointText.gameObject.SetActive(false);
    }
}
