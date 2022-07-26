using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Drain 100 health from an opponent, and give it to the player.
    /// </summary>
    [Serializable]
    internal class Vampire2ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 50;

        public override string PreActivationMessage => ""; // This command does not display a message.

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(Player player, Level level, Item item, int direction)
        {
            for (int i = 0; i < 3; i++)
            {
                if (SaveGame.Instance.SpellEffects.DrainLife(direction, 100))
                {
                    player.RestoreHealth(100);
                }
            }
            return true;
        }

        public override int Value => 2500;

        public override string Description => "vampiric drain (3*100) every 400 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResDark;

        public override uint SpecialAbilityFlag => ItemFlag3.SlowDigest;
    }
}
