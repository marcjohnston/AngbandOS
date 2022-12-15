using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Shoot an arrow that does 150 damage.
    /// </summary>
    [Serializable]
    internal class BoMiss2ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 66;

        public override string PreActivationMessage => "It grows magical spikes...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(90) + 90;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBolt(new ProjectArrow(saveGame), direction, 150);
            return true;
        }

        public override int Value => 1000;

        public override string Description => "arrows (150) every 90+d90 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}
