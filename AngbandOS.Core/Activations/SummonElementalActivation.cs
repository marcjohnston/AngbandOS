namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Summon an elemental, with a 1-in-3 chance of it being hostile.
    /// </summary>
    [Serializable]
    internal class SummonElementalActivation : Activation
    {
        private SummonElementalActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 25;

        public override bool Activate()
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                if (SaveGame.Level.SummonSpecific(SaveGame.Player.MapY, SaveGame.Player.MapX, (int)(SaveGame.Player.Level * 1.5), new ElementalMonsterSelector()))
                {
                    SaveGame.MsgPrint("An elemental materializes...");
                    SaveGame.MsgPrint("You fail to control it!");
                }
            }
            else
            {
                if (SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, (int)(SaveGame.Player.Level * 1.5), new ElementalMonsterSelector(), SaveGame.Player.Level == 50))
                {
                    SaveGame.MsgPrint("An elemental materializes...");
                    SaveGame.MsgPrint("It seems obedient to you.");
                }
            }
            return true;
        }

        public override int RechargeTime(Player player) => 750;

        public override int Value => 15000;

        public override string Description => "summon elemental every 750 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
    }
}
