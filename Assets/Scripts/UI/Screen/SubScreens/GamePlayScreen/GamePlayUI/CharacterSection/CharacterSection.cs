using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

namespace CampusTyconn
{
    public class CharacterSection : GameSection
    {
        public ExternalFeatureViewer moneyViewer;

        public ExternalFeatureViewer debtViewer;

        public ExternalFeatureViewer dayViewer;

        public List<CharacterValueViewer> characterValueViewers;

        public override void InitiliazeSection(CharacterData characterData)
        {
            List<Feature> allFeatures = characterData.GetAllFeatures();

            var viewAndFeatures = allFeatures.Zip(characterValueViewers, (f, w) => new { Feature = f,Viewer = w });

            foreach (var pair in viewAndFeatures)
            {
                pair.Viewer.SetCharacterValueViewer(pair.Feature);
            }

            moneyViewer.UpdateValue(characterData.money.moneyAmount);

            characterData.money.OnMoneyAmountChanged += moneyViewer.UpdateValue;

            debtViewer.UpdateValue(characterData.debt.debtAmount);

            characterData.debt.OnDebtValueChanged += debtViewer.UpdateValue;

            dayViewer.UpdateValue(characterData.day.deltaDay);

            characterData.day.OnDayPassed += dayViewer.UpdateValue;

        }

        public override void ReleaseMessage(string messega)
        {
            base.OnGameSectionMessageReleased?.Invoke(messega);
        }
    }
}
