using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSelection : MonoBehaviour
{
    public abstract void Initiliaze();

    public abstract bool selectionCompleted();
}
