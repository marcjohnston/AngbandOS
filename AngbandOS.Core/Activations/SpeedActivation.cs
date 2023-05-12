namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Give us temporary haste.
    /// </summary>
    [Serializable]
    internal class SpeedActivation : Activation
    {
        private SpeedActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 25;

        public override string? PreActivationMessage => "It glows bright green...";

        public override bool Activate()
        {
            if (SaveGame.Player.TimedHaste.TurnsRemaining == 0)
            {
                SaveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(20) + 20);
            }
            else
            {
                SaveGame.Player.TimedHaste.AddTimer(5);
            }
            return true;
        }

        public override int RechargeTime(Player player) => 250;

        public override int Value => 15000;

        public override string Description => "speed (dur 20+d20) every 250 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}
