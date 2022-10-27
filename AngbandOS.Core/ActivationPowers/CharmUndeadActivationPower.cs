using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Charm an undead.
    /// </summary>
    [Serializable]
    internal class CharmUndeadActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 333;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.ControlOneUndead(direction, saveGame.Player.Level);
            return true;
        }

        public override int Value => 10000;

        public override string Description => "enslave undead every 333 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;
            
        public override uint SpecialPowerFlag => ItemFlag2.ResBlind;

        public override uint SpecialAbilityFlag => ItemFlag3.SeeInvis;
    }
}
