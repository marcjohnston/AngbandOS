﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellTeleport : Spell
{
    private TarotSpellTeleport(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TeleportPlayer(SaveGame.ExperienceLevel * 4);
    }

    public override string Name => "Teleport";
    
    protected override string? Info()
    {
        return $"range {SaveGame.ExperienceLevel * 4}";
    }
}