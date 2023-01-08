namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Heal 700 health and remove all bleeding.
    /// </summary>
    [Serializable]
    internal class Cure700ActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "It glows deep blue...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.MsgPrint("You feel a warm tingling inside...");
            saveGame.Player.RestoreHealth(700);
            saveGame.Player.TimedBleeding.SetTimer(0);
            return true;
        }

        public override int RechargeTime(Player player) => 250;

        public override int Value => 10000;

        public override string Description => "heal 700 hit points every 250 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
    }
}
