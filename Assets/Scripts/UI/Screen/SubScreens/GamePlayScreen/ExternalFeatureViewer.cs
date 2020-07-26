using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace CampusTyconn
{
    public class ExternalFeatureViewer : MonoBehaviour
    {
        public Text featureViewerValue;

        private void Start()
        {
            featureViewerValue = GetComponentInChildren<Text>();
        }

        public void UpdateValue(int value)
        {
            featureViewerValue.text = "" + value;
        }
    }
}
