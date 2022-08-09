using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Confuse an opponent.
    /// </summary>
    [Serializable]
    internal class ConfuseActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It glows in scintillating colours...";

        public override int RechargeTime(Player player) => 15;

        protected override string PostAimingMessage => "";

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.ConfuseMonster(direction, 20);
            return true;
        }

        public override int Value => 500;

        public override string Description => "confuse monster every 15 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResDisen;

        public override uint SpecialAbilityFlag => ItemFlag3.Telepathy;
    }
}
