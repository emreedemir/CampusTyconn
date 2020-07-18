using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace CampusTyconn
{
    public class CharacterSection : GameSection, ICharacterObserver
    {
        public CharacterValueViewer happinessValueViewer;

        public CharacterValueViewer selfRealizationValueViewer;

        public CharacterValueViewer respectValueViewer;

        public CharacterValueViewer healthValueViewer;

        public CharacterValueViewer popularityValueViewer;

        public override void InitiliazeSection(CharacterData characterData)
        {
            /*
            happinessValueViewer.SetCharacterValueViewer(character.happiness.GetType().Name.ToUpper(), character.happiness);

            character.OnHappinessChanged += happinessValueViewer.UpdateValue;

            selfRealizationValueViewer.SetCharacterValueViewer(character.selfRealization.GetType().Name.ToUpper(), character.selfRealization);

            character.OnSelfRealizationChanged += selfRealizationValueViewer.UpdateValue;

            respectValueViewer.SetCharacterValueViewer(character.selfRealization.GetType().Name.ToUpper(), character.respect);

            character.OnRespectChanged += selfRealizationValueViewer.UpdateValue;

            healthValueViewer.SetCharacterValueViewer(character.health.GetType().Name.ToUpper(), character.health);

            character.OnHealthChanged += healthValueViewer.UpdateValue;

            popularityValueViewer.SetCharacterValueViewer(character.popularity.GetType().Name.ToUpper(), character.popularity);

            character.OnPopularityChanged += popularityValueViewer.UpdateValue;
            */
        }

        public void UpdateCharacterValues(Character character)
        {

        }
    }
}
