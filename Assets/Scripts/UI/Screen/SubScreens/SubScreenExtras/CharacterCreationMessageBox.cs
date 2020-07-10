using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationMessageBox : MonoBehaviour
{
    public RectTransform upPosition;

    public RectTransform downPosition;

    public Text messageBoxText;

    public void NotifyMessage(string message)
    {
        StartCoroutine(MessageBoxCoroutine(message));
    }

    IEnumerator MessageBoxCoroutine(string message)
    {
        this.transform.position = upPosition.position;

        messageBoxText.text = message;

        iTween.MoveTo(this.gameObject, downPosition.position, 1);

        yield return new WaitUntil(() => this.gameObject.transform.position == downPosition.position);

        iTween.MoveTo(this.gameObject, upPosition.position, 2);
    }
}
