﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellPhantasmalServant : Spell
{
    private TarotSpellPhantasmalServant(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.MsgPrint(
            SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel * 3 / 2, new PhantomMonsterSelector(), false)
                ? "'Your wish, master?'"
                : "No-one ever turns up.");
    }

    public override string Name => "Phantasmal Servant";
    
    protected override string? Info()
    {
        return "control 100%";
    }
}