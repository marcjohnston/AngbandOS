using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Drain up to 50 life from an opponent, and give it to the player.
    /// </summary>
    [Serializable]
    internal class Vampire1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 66;

        public override string PreActivationMessage => ""; // This power does not reveal itself to the player.

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(Player player, Level level, int direction)
        {
            for (int i = 0; i < 3; i++)
            {
                if (SaveGame.Instance.SpellEffects.DrainLife(direction, 50))
                {
                    player.RestoreHealth(50);
                }
            }
            return true;
        }

        public override int Value => 1000;

        public override string Description => "vampiric drain (3*50) every 400 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResShards;

        public override uint SpecialAbilityFlag => ItemFlag2.FreeAct;
    }
}
