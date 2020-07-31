using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using CampusTyconn;

namespace CampusTyconn
{
    public class SocialEventButton : MonoBehaviour, IPointerClickHandler
    {
        public Text socialEventNameText;

        public Text socialEventTargetName;

        public Text dayText;

        public Text costText;

        public Action<SocialEventButton> OnPressed;

        public SocialEvent socialEvent;

        public void SetSocialEventButton(SocialEvent socialEvent)
        {
            this.socialEvent = socialEvent;

            this.socialEventNameText.text = socialEvent.eventName;

            string targetName = "";

            foreach (KeyValuePair<Feature, int> pair in socialEvent.targetFeatures)
            {
                targetName += pair.Key.featureName + " => " + pair.Value + ", ";
            }

            socialEventTargetName.text = targetName;

            dayText.text = socialEvent.eventTime + "";

            costText.text = socialEvent.eventCost + "";

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnPressed?.Invoke(this);
        }

        public void MarkAsPressed()
        {
            StartCoroutine(MarkCoroutine(Color.green));
        }

        public void MarkAsWarning()
        {
            StartCoroutine(MarkCoroutine(Color.red));
        }

        IEnumerator MarkCoroutine(Color color)
        {
            this.GetComponent<Image>().color = color;

            yield return new WaitForSeconds(2);

            GetComponent<Image>().color = Color.gray;
        }
    }

}
