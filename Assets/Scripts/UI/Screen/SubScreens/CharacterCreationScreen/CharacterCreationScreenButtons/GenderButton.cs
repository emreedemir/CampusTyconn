using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
namespace CampusTyconn
{
    public class GenderButton : MonoBehaviour, IPointerClickHandler
    {
        public Gender gender;

        public Action<GenderButton> OnClicked;

        public void SetGenderButton(Gender gender)
        {
            this.gender = gender;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(this);
        }

        public void MarkAsSelected()
        {

        }

        public void MarkAsDeselected()
        {

        }
    }
}
