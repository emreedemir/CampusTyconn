using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CampusTyconn
{
    public class CharacterValueViewer : MonoBehaviour
    {
        public Text valueNameText;

        public Slider slider;

        public void SetCharacterValueViewer(Feature feature)
        {
            valueNameText.text = feature.featureName;

            slider.value = 0;

            UpdateValue(feature.featureValue);

            feature.OnFeatureUpdated += UpdateValue;
        }

        public void UpdateValue(int value)
        {
            Debug.Log(value +"Feature Value");
            Debug.Log("UPDATED");

            slider.value =  value;

            if (value < 20)
            {
                MarkAsLow();
            }
            else
            {
                MarkAsHigh();
            }
        }

        void MarkAsLow()
        {

        }

        void MarkAsHigh()
        {

        }

    }

}
