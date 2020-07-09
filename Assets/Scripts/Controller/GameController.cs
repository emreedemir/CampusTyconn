using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void CreateNewCharacter(Character character)
    {
        DataUtility.SaveCharacter(character);

       // FindObjectOfType<MainScreensController>().OpenMainGamePlayScreen();
    }
}
