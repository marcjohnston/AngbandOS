using AngbandOS.Core.MonsterSelectors;
using AngbandOS.Enumerations;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Summon an elemental, with a 1-in-3 chance of it being hostile.
    /// </summary>
    [Serializable]
    internal class SummonElementalActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "";

        public override bool Activate(SaveGame saveGame)
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, (int)(saveGame.Player.Level * 1.5), new ElementalMonsterSelector()))
                {
                    saveGame.MsgPrint("An elemental materializes...");
                    saveGame.MsgPrint("You fail to control it!");
                }
            }
            else
            {
                if (saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, (int)(saveGame.Player.Level * 1.5), new ElementalMonsterSelector(), saveGame.Player.Level == 50))
                {
                    saveGame.MsgPrint("An elemental materializes...");
                    saveGame.MsgPrint("It seems obedient to you.");
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
