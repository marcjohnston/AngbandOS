using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Shoot a frost ball that does 100 damage.
    /// </summary>
    [Serializable]
    internal class BaCold2ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 0; // TODO: Confirm this artifact does not have a corresponding random chance.  It is only used with biased artifacts.

        public override string PreActivationMessage => "It glows an intense blue...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 300;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBall(new ProjectCold(saveGame), direction, 100, 2);
            return true;
        }

        public override int Value => 1250;

        public override string Description => "ball of cold (100) every 300 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResBlind = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
    }
}
