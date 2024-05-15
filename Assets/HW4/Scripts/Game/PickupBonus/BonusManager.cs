using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class BonusManager : MonoBehaviour
    {
        private void Start()
        {
            BonusBehaviour.OnBonusPick += ManageBonus;
        }

        private void OnDestroy()
        {
            BonusBehaviour.OnBonusPick -= ManageBonus;
        }

        private void ManageBonus(BonusType bonusType)
        {
            switch (bonusType)
            {
                case BonusType.ExtraLife:
                    LivesSystem.Instance.EditLives(1);
                    break;
                case BonusType.BiggerBall:
                    break;
            }
        }
    }
}