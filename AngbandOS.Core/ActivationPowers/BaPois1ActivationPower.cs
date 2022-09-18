using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Shoot a 12-damage ball of poison
    /// </summary>
    [Serializable]
    internal class BaPois1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It throbs deep green...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(4) + 4;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBall(new ProjectPois(saveGame), direction, 12, 3);
            return true;
        }

        public override int Value => 300;

        public override string Description => "stinking cloud (12), rad. 3, every 4+d4 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResShards;

        public override uint SpecialAbilityFlag => ItemFlag3.Telepathy;
    }
}
