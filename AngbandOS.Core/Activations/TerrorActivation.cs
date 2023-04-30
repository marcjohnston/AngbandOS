namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Scare monsters with a 40+level strength.
    /// </summary>
    [Serializable]
    internal class TerrorActivation : Activation
    {
        private TerrorActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 75;

        public override int RechargeTime(Player player) => 3 * (player.Level + 10);

        public override bool Activate()
        {
            SaveGame.TurnMonsters(40 + SaveGame.Player.Level);
            return true;
        }

        public override int Value => 2500;

        public override string Description => "terror every 3 * (level+10) turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
    }
}
