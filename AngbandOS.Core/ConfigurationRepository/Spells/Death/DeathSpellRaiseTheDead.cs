﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellRaiseTheDead : Spell
{
    private DeathSpellRaiseTheDead(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (SaveGame.Rng.DieRoll(3) == 1)
        {
            if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel * 3 / 2, SaveGame.ExperienceLevel > 47 ? new HiUndeadMonsterSelector() : new UndeadMonsterSelector()))
            {
                SaveGame.MsgPrint(
                    "Cold winds begin to swirl around you, carrying with them the stench of decay...");
                SaveGame.MsgPrint("'The dead arise... to punish you for disturbing them!'");
            }
            else
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else
        {
            if (SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel * 3 / 2,
                SaveGame.ExperienceLevel > 47 ? new HiUndeadNoUniquesMonsterSelector() : new UndeadMonsterSelector(), SaveGame.ExperienceLevel > 24 && SaveGame.Rng.DieRoll(3) == 1))
            {
                SaveGame.MsgPrint(
                    "Cold winds begin to swirl around you, carrying with them the stench of decay...");
                SaveGame.MsgPrint("Ancient, long-dead forms arise from the ground to serve you!");
            }
            else
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(25, 3);
    }

    public override string Name => "Raise the Dead";
    
    protected override string? Info()
    {
        return "control 67%";
    }
}