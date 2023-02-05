namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Charm a monster.
    /// </summary>
    [Serializable]
    internal class CharmOtherActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.CharmMonster(direction, saveGame.Player.Level);
            return true;
        }

        public override int Value => 10000;

        public override string Description => "charm monster every 400 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
    }
}
