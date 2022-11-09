using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Shoot a lightning bolt that does 4d8 damage
    /// </summary>
    [Serializable]
    internal class BoElec1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It is covered in sparks...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(6) + 6;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBolt(new ProjectElec(saveGame), direction, Program.Rng.DiceRoll(4, 8));
            return true;
        }

        public override int Value => 250;

        public override string Description => "lightning bolt (4d8) every 6+d6 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
    }
}
