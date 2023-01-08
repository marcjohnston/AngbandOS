namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Give us temporary invulnerabliity.
    /// </summary>
    [Serializable]
    internal class InvulnActivationPower : ActivationPower
    {
        public override int RandomChance => 5;

        public override string PreActivationMessage => "";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.TimedInvulnerability.SetTimer(saveGame.Player.TimedInvulnerability.TimeRemaining + Program.Rng.DieRoll(8) + 8);
            return true;
        }

        public override int RechargeTime(Player player) => 1000;

        public override int Value => 25000;

        public override string Description => "invulnerability (dur 8+d8) every 1000 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
    }
}
