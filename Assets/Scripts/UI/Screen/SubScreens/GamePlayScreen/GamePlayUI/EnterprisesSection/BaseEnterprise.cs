using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseEnterprise : MonoBehaviour
{
    public Action<string> OnMessageReleased;

    public abstract void InitiliazeEnterprise(Character character);
}
