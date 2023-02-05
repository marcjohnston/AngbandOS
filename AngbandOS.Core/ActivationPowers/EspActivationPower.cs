namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Give temporary telepathy.
    /// </summary>
    [Serializable]
    internal class EspActivationPower : ActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.TimedTelepathy.AddTimer(Program.Rng.DieRoll(30) + 25);
            return true;
        }

        public override int RechargeTime(Player player) => 200;

        public override int Value => 1500;

        public override string Description => "temporary ESP (dur 25+d30) every 200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
    }
}
