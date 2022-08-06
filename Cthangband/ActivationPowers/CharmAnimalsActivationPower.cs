using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Charm multiple animals.
    /// </summary>
    [Serializable]
    internal class CharmAnimalsActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "";

        public override int RechargeTime(Player player) => 500;

        public override bool Activate(Player player, Level level)
        {
            SaveGame.Instance.CharmAnimals(player.Level * 2);
            return true;
        }

        public override int Value => 12500;

        public override string Description => "animal friendship every 500 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResSound;

        public override uint SpecialAbilityFlag => ItemFlag3.SlowDigest;
    }
}
