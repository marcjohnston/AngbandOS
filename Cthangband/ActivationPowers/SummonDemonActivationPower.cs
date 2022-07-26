using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Summon a demon, with a 1-in-3 chance of it being hostile.
    /// </summary>
    [Serializable]
    internal class SummonDemonActivationPower : ActivationPower
    {
        public override int RandomChance => 5;

        public override string PreActivationMessage => "";

        public override bool Activate(Player player, Level level)
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                if (level.Monsters.SummonSpecific(player.MapY, player.MapX, (int)(player.Level * 1.5), Constants.SummonDemon))
                {
                    Profile.Instance.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                    Profile.Instance.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
                }
            }
            else
            {
                if (level.Monsters.SummonSpecificFriendly(player.MapY, player.MapX, (int)(player.Level * 1.5), Constants.SummonDemon, player.Level == 50))
                {
                    Profile.Instance.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                    Profile.Instance.MsgPrint("'What is thy bidding... Master?'");
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
