using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Light the area.
    /// </summary>
    [Serializable]
    internal class LightActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It wells with clear light...";

        public override bool Activate(Player player, Level level, Item item)
        {
            SaveGame.Instance.SpellEffects.LightArea(Program.Rng.DiceRoll(2, 15), 3);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(10) + 10;

        public override int Value => 150;

        public override string Description => "light area (dam 2d15) every 10+d10 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResConf;

        public override uint SpecialAbilityFlag => ItemFlag2.HoldLife;
    }
}
