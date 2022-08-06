using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Rock to mud.
    /// </summary>
    [Serializable]
    internal class StoneMudActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It pulsates...";

        protected override string PostAimingMessage => throw new System.NotImplementedException();

        public override int RechargeTime(Player player) => 5;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.WallToMud(direction);
            return true;
        }

        public override int Value => 1000;

        public override string Description => "stone to mud every 5 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResBlind;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}
