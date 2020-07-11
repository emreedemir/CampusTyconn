using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterValueViewer : MonoBehaviour
{
    public Text valueNameText;

    public Slider slider;

    public void SetCharacterValueViewer(string valueName,int initialValue)
    {
        valueNameText.name = valueName;

        slider.value = initialValue;

        if (initialValue < 10)
        {
            MarkAsLow();
        }
    }

    public void UpdateValue(int deltaValue)
    {
       
        slider.value += deltaValue*10;
    }

    void MarkAsLow()
    {
        
    }

    void MarkAsHigh()
    {

    }

    IEnumerator UpdateSliderValueCoroutine(int changedValue)
    {
        yield return new WaitForSeconds(1f);
    }
}
