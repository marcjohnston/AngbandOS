// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellConjureElemental : Spell
{
    private TarotSpellConjureElemental(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (Program.Rng.DieRoll(6) > 3)
        {
            if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, new ElementalMonsterSelector(), false))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else if (SaveGame.Level.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, new ElementalMonsterSelector()))
        {
            SaveGame.MsgPrint("You fail to control the elemental creature!");
        }
        else
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }

    public override string Name => "Conjure Elemental";
    
    protected override string? Info()
    {
        return "control 50%";
    }
}