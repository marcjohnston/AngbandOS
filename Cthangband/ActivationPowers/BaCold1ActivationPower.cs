using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Shoot a frost ball that does 48 damage.
    /// </summary>
    [Serializable]
    internal class BaCold1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "It is covered in frost...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(Player player, Level level, int direction)
        {
            SaveGame.Instance.FireBall(new ProjectCold(), direction, 48, 2);
            return true;
        }

        public override int Value => 750;

        public override string Description => "ball of cold (48) every 400 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResPois;

        public override uint SpecialAbilityFlag => ItemFlag3.Feather;
    }
}
