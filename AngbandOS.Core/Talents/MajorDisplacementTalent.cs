﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class MajorDisplacementTalent : Talent
{
    private MajorDisplacementTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Major Displacement";
    public override void Initialize(int characterClass)
    {
        Level = 7;
        ManaCost = 6;
        BaseFailure = 35;
    }

    public override void Use()
    {
        SaveGame.TeleportPlayer(SaveGame.ExperienceLevel * 5);
        if (SaveGame.ExperienceLevel > 29)
        {
            SaveGame.BanishMonsters(SaveGame.ExperienceLevel);
        }
    }

    protected override string Comment()
    {
        return $"range {SaveGame.ExperienceLevel * 5}";
    }
}