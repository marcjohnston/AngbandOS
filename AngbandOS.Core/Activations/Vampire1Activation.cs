namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Drain up to 50 life from an opponent, and give it to the player.
    /// </summary>
    [Serializable]
    internal class Vampire1Activation : DirectionalActivation
    {
        private Vampire1Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 66;

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(int direction)
        {
            for (int i = 0; i < 3; i++)
            {
                if (SaveGame.DrainLife(direction, 50))
                {
                    SaveGame.Player.RestoreHealth(50);
                }
            }
            return true;
        }

        public override int Value => 1000;

        public override string Description => "vampiric drain (3*50) every 400 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
    }
}
