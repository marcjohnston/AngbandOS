using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    [Serializable]
    internal class BaFire1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "It glows an intense red...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(Player player, Level level, int direction)
        {
            SaveGame.Instance.FireBall(new ProjectFire(), direction, 72, 2);
            return true;
        }

        public override int Value => 1000;

        public override string Description => "ball of fire (72) every 400 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResDark;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}
