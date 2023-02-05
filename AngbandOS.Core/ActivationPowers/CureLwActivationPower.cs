namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Heal 30 health and remove fear.
    /// </summary>
    [Serializable]
    internal class CureLwActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.TimedFear.ResetTimer();
            saveGame.Player.RestoreHealth(30);
            return true;
        }

        public override int RechargeTime(Player player) => 10;

        public override int Value => 500;

        public override string Description => "remove fear & heal 30 hp every 10 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}
