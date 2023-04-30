namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Restore all ability drain and lost experience.
    /// </summary>
    [Serializable]
    internal class RestAllActivation : Activation
    {
        private RestAllActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 33;

        public override string? PreActivationMessage => "It glows a deep green...";

        public override bool Activate()
        {
            SaveGame.Player.TryRestoringAbilityScore(Ability.Strength);
            SaveGame.Player.TryRestoringAbilityScore(Ability.Intelligence);
            SaveGame.Player.TryRestoringAbilityScore(Ability.Wisdom);
            SaveGame.Player.TryRestoringAbilityScore(Ability.Dexterity);
            SaveGame.Player.TryRestoringAbilityScore(Ability.Constitution);
            SaveGame.Player.TryRestoringAbilityScore(Ability.Charisma);
            SaveGame.Player.RestoreLevel();
            return true;
        }

        public override int RechargeTime(Player player) => 750;

        public override int Value => 15000;

        public override string Description => "restore stats and life levels every 750 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
