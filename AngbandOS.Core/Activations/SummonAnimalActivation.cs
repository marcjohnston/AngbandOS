namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Summon animals.
    /// </summary>
    [Serializable]
    internal class SummonAnimalActivation : Activation
    {
        private SummonAnimalActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 40;

        public override bool Activate()
        {
            SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Player.Level, new AnimalRangerMonsterSelector(), true);
            return true;
        }

        public override int RechargeTime(Player player) => 200 + Program.Rng.DieRoll(300);

        public override int Value => 10000;

        public override string Description => "summon animal every 200+d300 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
    }
}
