using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusTyconn
{
    public class EnterpriseSection : GameSection
    {
        public BasicButton openHospitalEnterpriseButton;

        public BasicButton openBankEnterpriseButton;


        public override void InitiliazeSection(CharacterData characterData)
        {

        }

        public void OnHospitalEnterpriseButtonPressed()
        {

        }

        public void OnBankEnterpriseButtonPressed()
        {

        }

        public override void ReleaseMessage(string messega)
        {
            base.OnGameSectionMessageReleased?.Invoke(messega);
        }
    }
}
