namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Give us temporary resistance to the basic elements.
    /// </summary>
    [Serializable]
    internal class ResistAllActivationPower : ActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "It glows many colours...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.TimedAcidResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
            saveGame.Player.TimedLightningResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
            saveGame.Player.TimedFireResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
            saveGame.Player.TimedColdResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
            saveGame.Player.TimedPoisonResistance.AddTimer(Program.Rng.DieRoll(40) + 40);
            return true;
        }

        public override int RechargeTime(Player player) => 200;

        public override int Value => 5000;

        public override string Description => "resist elements (dur 40+d40) every 200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
    }
}
