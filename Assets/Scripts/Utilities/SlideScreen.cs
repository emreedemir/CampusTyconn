using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideScreen : Singleton<SlideScreen>
{
    public RectTransform left;
    public RectTransform centerPosition;
    public RectTransform right;

    public GameObject layerObject;

    public LayerMask layer;

    public void SlideScreens(Transform current, Transform come, SlideType slideType)
    {
        layerObject.gameObject.SetActive(true);

        if (slideType == SlideType.ToLeft)
        {
            StartCoroutine(SlideScreensToLeft(current, come));
        }
        else if (slideType == SlideType.ToRight)
        {
            StartCoroutine(SlideScreensToRight(current, come));
        }
    }

    private IEnumerator SlideScreensToLeft(Transform center, Transform come)
    {
        come.transform.position = right.position;

        come.gameObject.SetActive(true);

        iTween.MoveTo(center.gameObject, left.position, 1);

        iTween.MoveTo(come.gameObject, centerPosition.position, 1);

        yield return new WaitUntil(() => come.position == centerPosition.position);

        layerObject.SetActive(false);
    }

    private IEnumerator SlideScreensToRight(Transform center, Transform come)
    {
        come.transform.position = left.position;

        come.gameObject.SetActive(true);

        iTween.MoveTo(come.gameObject, centerPosition.position, 1);

        iTween.MoveTo(center.gameObject, right.position, 1);

        yield return new WaitUntil(() => come.position == centerPosition.position);

        layerObject.gameObject.SetActive(false);
    }
}

public enum SlideType
{
    None,
    ToLeft,
    ToRight
}