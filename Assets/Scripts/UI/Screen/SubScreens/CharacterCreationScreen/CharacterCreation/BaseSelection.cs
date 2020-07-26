using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CampusTyconn
{
    public abstract class BaseSelection : MonoBehaviour
    {
        public abstract void Initiliaze();

        public abstract bool SelectionCompleted(CharacterCreationData characterCreationData);

        public Action<string> OnMessageReleased;
    }
}
