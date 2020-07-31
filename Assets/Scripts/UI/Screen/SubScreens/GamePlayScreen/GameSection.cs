using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CampusTyconn
{
    public abstract class GameSection : MonoBehaviour
    {

        public Action<string> OnGameSectionMessageReleased;

        public abstract void InitiliazeSection(CharacterData characterData);

        public abstract void ReleaseMessage(string messega);
    }
}
