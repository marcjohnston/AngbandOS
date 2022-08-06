using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Charm a monster.
    /// </summary>
    [Serializable]
    internal class CharmOtherActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(Player player, Level level, int direction)
        {
            SaveGame.Instance.CharmMonster(direction, player.Level);
            return true;
        }

        public override int Value => 10000;

        public override string Description => "charm monster every 400 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResConf;

        public override uint SpecialAbilityFlag => ItemFlag3.Telepathy;
    }
}
