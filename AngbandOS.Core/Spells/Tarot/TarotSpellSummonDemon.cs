// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellSummonDemon : Spell
{
    private TarotSpellSummonDemon(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.MsgPrint("You concentrate on the image of a demon...");
        if (Program.Rng.DieRoll(10) > 3)
        {
            if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, new DemonMonsterSelector(), true))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else if (SaveGame.Level.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, new DemonMonsterSelector()))
        {
            SaveGame.MsgPrint("The summoned demon gets angry!");
        }
        else
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }

    public override string Name => "Summon Demon";
    
    protected override string? Info()
    {
        return "control 70%";
    }
}