using AngbandOS.Enumerations;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Restore lost experience.
    /// </summary>
    [Serializable]
    internal class RestLifeActivationPower : ActivationPower
    {
        public override int RandomChance => 66;

        public override string PreActivationMessage => "It glows a deep red...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.RestoreLevel();
            return true;
        }

        public override int RechargeTime(Player player) => 450;

        public override int Value => 7500;

        public override string Description => "restore life levels every 450 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
    }
}
