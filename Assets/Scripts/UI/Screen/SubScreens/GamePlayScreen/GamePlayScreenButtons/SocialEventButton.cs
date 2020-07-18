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

        public Text socialEventFeautreTargetPlus;

        public Text socialEventCostText;
 
        public Action<SocialEvent> OnPressed;

        public Action<SocialEvent> OnEventEnded;

        public Slider slider;

        public SocialEvent socialEvent;

        public void SetSocialEventButton(SocialEvent socialEvent)
        {
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnPressed?.Invoke(socialEvent);
        }

        public void StartEventForButton()
        {
            StartCoroutine(StartEventCoroutine(socialEvent.eventTime));
        }

        public void EndEventForButton()
        {
            //Change slider color
        }

        IEnumerator StartEventCoroutine(int eventTime)
        {
            //Slider Animation
            yield return new WaitForSeconds(1f);

            OnEventEnded?.Invoke(socialEvent);
        }
    }

}
