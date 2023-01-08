namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Give us extra haste for a long time.
    /// </summary>
    [Serializable]
    internal class XtraSpeedActivationPower : ActivationPower
    {
        public override int RandomChance => 10;

        public override string PreActivationMessage => "It glows brightly...";

        public override bool Activate(SaveGame saveGame)
        {
            if (saveGame.Player.TimedHaste.TimeRemaining == 0)
            {
                saveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(75) + 75);
            }
            else
            {
                saveGame.Player.TimedHaste.SetTimer(saveGame.Player.TimedHaste.TimeRemaining + 5);
            }
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(200) + 200;

        public override int Value => 25000;

        public override string Description => "speed (dur 75+d75) every 200+d200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
    }
}
