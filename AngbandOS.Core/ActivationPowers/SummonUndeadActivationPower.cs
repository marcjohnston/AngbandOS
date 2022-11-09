using AngbandOS.Core;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Summon undead, with a 1-in-3 chance of it being hostile.
    /// </summary>
    [Serializable]
    internal class SummonUndeadActivationPower : ActivationPower
    {
        public override int RandomChance => 5;

        public override string PreActivationMessage => "";

        public override bool Activate(SaveGame saveGame)
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, (int)(saveGame.Player.Level * 1.5), saveGame.Player.Level > 47 ? Constants.SummonHiUndead : Constants.SummonUndead))
                {
                    saveGame.MsgPrint("Cold winds begin to Attack around you, carrying with them the stench of decay...");
                    saveGame.MsgPrint("'The dead arise... to punish you for disturbing them!'");
                }
            }
            else
            {
                if (saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, (int)(saveGame.Player.Level * 1.5), saveGame.Player.Level > 47 ? Constants.SummonHiUndeadNoUniques : Constants.SummonUndead, saveGame.Player.Level > 24 && Program.Rng.DieRoll(3) == 1))
                {
                    saveGame.MsgPrint("Cold winds begin to Attack around you, carrying with them the stench of decay...");
                    saveGame.MsgPrint("Ancient, long-dead forms arise from the ground to serve you!");
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
