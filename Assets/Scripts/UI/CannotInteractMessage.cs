using System.Collections;
using TMPro;
using UnityEngine;

public class CannotInteractMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private float messageLifeTime;

    public void ShowMessage(string text)
    {
        message.text = text;
        StartCoroutine(nameof(MessageShowRoutine));
    }

    private IEnumerator MessageShowRoutine()
    {
        yield return new WaitForSeconds(messageLifeTime);
        message.text = "";
    }

    public void HideMessage()
    {
        StopCoroutine(nameof(MessageShowRoutine));
    }
}