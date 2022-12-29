namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Shoot a frost ball that does 200 damage with a larger radius.
    /// </summary>
    [Serializable]
    internal class BaCold3ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 50;

        public override string PreActivationMessage => "It glows bright white...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(325) + 325;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBall(new ProjectCold(saveGame), direction, 200, 3);
            return true;
        }

        public override int Value => 2500;

        public override string Description => "ball of cold (200) every 325+d325 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}
