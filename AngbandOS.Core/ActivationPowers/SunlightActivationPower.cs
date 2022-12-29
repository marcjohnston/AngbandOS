namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Aim a line of light in a direction of the player's choice
    /// </summary>
    [Serializable]
    internal class SunlightActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "";

        protected override string PostAimingMessage => "A line of sunlight appears.";

        public override int RechargeTime(Player player) => 10;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.LightLine(direction);
            return true;
        }

        public override int Value => 250;

        public override string Description => "beam of sunlight every 10 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}