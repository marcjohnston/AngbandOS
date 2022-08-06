using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Shoot a frost bolt that does 6d8 damage.
    /// </summary>
    [Serializable]
    internal class BoCold1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It is covered in frost...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(7) + 7;

        protected override bool Activate(Player player, Level level, int direction)
        {
            SaveGame.Instance.FireBolt(new ProjectCold(), direction, Program.Rng.DiceRoll(6, 8));
            return true;
        }

        public override int Value => 250;

        public override string Description => "frost bolt (6d8) every 7+d7 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResChaos;

        public override uint SpecialAbilityFlag => ItemFlag2.FreeAct;
    }
}
