namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Shoot a lightning storm that does 100 damage with a larger radius.
    /// </summary>
    [Serializable]
    internal class BaElec2ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 0; // TODO: Confirm this artifact does not have a corresponding random chance.  It is only used with biased artifacts.

        public override string PreActivationMessage => "It crackles with electricity...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 500;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBall(new ProjectElec(saveGame), direction, 100, 3);
            return true;
        }

        public override int Value => 1500;

        public override string Description => "ball of lightning (100) every 500 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
    }
}
