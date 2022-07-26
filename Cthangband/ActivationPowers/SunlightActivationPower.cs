using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Aim a line of light in a direction of the player's choice
    /// </summary>
    [Serializable]
    internal class SunlightActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "";

        protected override string PostAimingMessage => "A line of sunlight appears.";

        public override int RechargeTime(Player player) => 10;

        protected override bool Activate(Player player, Level level, Item item, int direction)
        {
            SaveGame.Instance.SpellEffects.LightLine(direction);
            return true;
        }

        public override int Value => 250;

        public override string Description => "beam of sunlight every 10 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResConf;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}