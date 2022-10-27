using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Summon a demon, with a 1-in-3 chance of it being hostile.
    /// </summary>
    [Serializable]
    internal class SummonDemonActivationPower : ActivationPower
    {
        public override int RandomChance => 5;

        public override string PreActivationMessage => "";

        public override bool Activate(SaveGame saveGame)
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, (int)(saveGame.Player.Level * 1.5), Constants.SummonDemon))
                {
                    saveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                    saveGame.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
                }
            }
            else
            {
                if (saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, (int)(saveGame.Player.Level * 1.5), Constants.SummonDemon, saveGame.Player.Level == 50))
                {
                    saveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                    saveGame.MsgPrint("'What is thy bidding... Master?'");
                }
            }
            return true;
        }

        public override int RechargeTime(Player player) => 666 + Program.Rng.DieRoll(333);

        public override int Value => 20000;

        public override string Description => "summon demon every 666+d333 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResDisen;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}
