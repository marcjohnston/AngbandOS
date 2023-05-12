namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Shoot a magic missile that does 2d6 damage
    /// </summary>
    [Serializable]
    internal class BoMiss1Activation : DirectionalActivation
    {
        private BoMiss1Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It glows extremely brightly...";

        public override int RechargeTime(Player player) => 2;

        protected override bool Activate(int direction)
        {
            SaveGame.FireBolt(new MissileProjectile(SaveGame), direction, Program.Rng.DiceRoll(2, 6));
            return true;
        }

        public override int Value => 250;

        public override string Description => "magic missile (2d6) every 2 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResSound = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
    }
}
