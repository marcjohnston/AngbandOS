namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Summon undead, with a 1-in-3 chance of it being hostile.
    /// </summary>
    [Serializable]
    internal class SummonUndeadActivation : Activation
    {
        private SummonUndeadActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 5;

        public override bool Activate()
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                if (SaveGame.Level.SummonSpecific(SaveGame.Player.MapY, SaveGame.Player.MapX, (int)(SaveGame.Player.Level * 1.5), SaveGame.Player.Level > 47 ? new HiUndeadMonsterSelector() : new UndeadMonsterSelector()))
                {
                    SaveGame.MsgPrint("Cold winds begin to Attack around you, carrying with them the stench of decay...");
                    SaveGame.MsgPrint("'The dead arise... to punish you for disturbing them!'");
                }
            }
            else
            {
                if (SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, (int)(SaveGame.Player.Level * 1.5), SaveGame.Player.Level > 47 ? new HiUndeadNoUniquesMonsterSelector() : new UndeadMonsterSelector(), SaveGame.Player.Level > 24 && Program.Rng.DieRoll(3) == 1))
                {
                    SaveGame.MsgPrint("Cold winds begin to Attack around you, carrying with them the stench of decay...");
                    SaveGame.MsgPrint("Ancient, long-dead forms arise from the ground to serve you!");
                }
            }
            return true;
        }

        public override int RechargeTime(Player player) => 666 + Program.Rng.DieRoll(333);

        public override int Value => 20000;

        public override string Description => "summon undead every 666+d333 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
    }
}
