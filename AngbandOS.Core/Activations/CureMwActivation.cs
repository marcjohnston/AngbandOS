namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Heal 4d8 health and reduce bleeding.
    /// </summary>
    [Serializable]
    internal class CureMwActivation : Activation
    {
        private CureMwActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It radiates deep purple...";

        public override bool Activate()
        {
            SaveGame.Player.RestoreHealth(Program.Rng.DiceRoll(4, 8));
            SaveGame.Player.TimedBleeding.SetTimer((SaveGame.Player.TimedBleeding.TurnsRemaining / 2) - 50);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(3) + 3;

        public override int Value => 750;

        public override string Description => "heal 4d8 & wounds every 3+d3 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNexus = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
    }
}
