namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Summon a demon, with a 1-in-3 chance of it being hostile.
    /// </summary>
    [Serializable]
    internal class SummonDemonActivation : Activation
    {
        private SummonDemonActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 5;

        public override bool Activate()
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                if (SaveGame.Level.SummonSpecific(SaveGame.Player.MapY, SaveGame.Player.MapX, (int)(SaveGame.Player.Level * 1.5), new DemonMonsterSelector()))
                {
                    SaveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                    SaveGame.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
                }
            }
            else
            {
                if (SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, (int)(SaveGame.Player.Level * 1.5), new DemonMonsterSelector(), SaveGame.Player.Level == 50))
                {
                    SaveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                    SaveGame.MsgPrint("'What is thy bidding... Master?'");
                }
            }
            return true;
        }

        public override int RechargeTime(Player player) => 666 + Program.Rng.DieRoll(333);

        public override int Value => 20000;

        public override string Description => "summon demon every 666+d333 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}
