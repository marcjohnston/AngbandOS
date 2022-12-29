namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Heal 1000 health and remove all bleeding.
    /// </summary>
    [Serializable]
    internal class Cure1000ActivationPower : ActivationPower
    {
        public override int RandomChance => 10;

        public override string PreActivationMessage => "It glows a bright white...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.MsgPrint("You feel much better...");
            saveGame.Player.RestoreHealth(1000);
            saveGame.Player.SetTimedBleeding(0);
            return true;
        }

        public override int RechargeTime(Player player) => 888;

        public override int Value => 15000;

        public override string Description => "heal 1000 hit points every 888 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}