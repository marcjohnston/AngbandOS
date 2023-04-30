namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Summon phantom warriors or beasts.
    /// </summary>
    [Serializable]
    internal class SummonPhantomActivation : Activation
    {
        private SummonPhantomActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 33;

        public override string? PreActivationMessage => "You summon a phantasmal servant.";

        public override bool Activate()
        {
            SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty, new PhantomMonsterSelector(), true);
            return true;
        }

        public override int RechargeTime(Player player) => 200 + Program.Rng.DieRoll(200);

        public override int Value => 12000;

        public override string Description => "summon phantasmal servant every 200+d200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNexus = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}
