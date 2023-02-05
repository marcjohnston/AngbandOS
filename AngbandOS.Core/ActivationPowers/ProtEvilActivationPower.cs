namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Give us protection from evil.
    /// </summary>
    [Serializable]
    internal class ProtEvilActivationPower : ActivationPower
    {
        public override int RandomChance => 75;

        public override string PreActivationMessage => "It lets out a shrill wail...";

        public override bool Activate(SaveGame saveGame)
        {
            int k = 3 * saveGame.Player.Level;
            saveGame.Player.TimedProtectionFromEvil.AddTimer(Program.Rng.DieRoll(25) + k);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(225) + 225;

        public override int Value => 5000;

        public override string Description => "protect evil (dur level*3 + d25) every 225+d225 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNexus = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
