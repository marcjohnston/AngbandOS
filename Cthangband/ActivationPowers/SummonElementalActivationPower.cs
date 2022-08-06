using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.ActivationPowers
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
                if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, (int)(saveGame.Player.Level * 1.5), Constants.SummonElemental))
                {
                    saveGame.Profile.MsgPrint("An elemental materializes...");
                    saveGame.Profile.MsgPrint("You fail to control it!");
                }
            }
            else
            {
                if (saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, (int)(saveGame.Player.Level * 1.5), Constants.SummonElemental, saveGame.Player.Level == 50))
                {
                    saveGame.Profile.MsgPrint("An elemental materializes...");
                    saveGame.Profile.MsgPrint("It seems obedient to you.");
                }
            }
            return true;
        }

        public override int RechargeTime(Player player) => 750;

        public override int Value => 15000;

        public override string Description => "summon elemental every 750 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResChaos;

        public override uint SpecialAbilityFlag => ItemFlag3.Feather;
    }
}
