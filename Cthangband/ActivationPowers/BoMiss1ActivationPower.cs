using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Shoot a magic missile that does 2d6 damage
    /// </summary>
    [Serializable]
    internal class BoMiss1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It glows extremely brightly...";

        public override int RechargeTime(Player player) => 2;

        protected override string PostAimingMessage => "";

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            SaveGame.Instance.FireBolt(new ProjectMissile(), direction, Program.Rng.DiceRoll(2, 6));
            return true;
        }

        public override int Value => 250;

        public override string Description => "magic missile (2d6) every 2 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResSound;

        public override uint SpecialAbilityFlag => ItemFlag3.SeeInvis;
    }
}
