using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Scare monsters with a 40+level strength.
    /// </summary>
    [Serializable]
    internal class TerrorActivationPower : ActivationPower
    {
        public override int RandomChance => 75;

        public override string PreActivationMessage => ""; // No message is displayed to the player.

        public override int RechargeTime(Player player) => 3 * (player.Level + 10);

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.TurnMonsters(40 + saveGame.Player.Level);
            return true;
        }

        public override int Value => 2500;

        public override string Description => "terror every 3 * (level+10) turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
    }
}
