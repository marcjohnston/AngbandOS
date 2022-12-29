namespace AngbandOS.ActivationPowers
{
    [Serializable]
    internal class BaFire1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "It glows an intense red...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBall(new ProjectFire(saveGame), direction, 72, 2);
            return true;
        }

        public override int Value => 1000;

        public override string Description => "ball of fire (72) every 400 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}
