﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class MinorDisplacementTalent : Talent
{
    private MinorDisplacementTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Minor Displacement";
    public override void Initialize(int characterClass)
    {
        Level = 3;
        ManaCost = 2;
        BaseFailure = 25;
    }

    public override void Use()
    {
        if (SaveGame.ExperienceLevel < 25)
        {
            SaveGame.TeleportPlayer(10);
        }
        else
        {
            SaveGame.MsgPrint("Choose a destination.");
            if (!SaveGame.TgtPt(out int i, out int j))
            {
                return;
            }
            SaveGame.Energy -= 60 - SaveGame.ExperienceLevel;
            if (!SaveGame.GridPassableNoCreature(j, i) || SaveGame.Grid[j][i].TileFlags.IsSet(GridTile.InVault) ||
                SaveGame.Grid[j][i].FeatureType.Name != "Water" ||
                SaveGame.Distance(j, i, SaveGame.MapY, SaveGame.MapX) > SaveGame.ExperienceLevel + 2 ||
                SaveGame.Rng.RandomLessThan(SaveGame.ExperienceLevel * SaveGame.ExperienceLevel / 2) == 0)
            {
                SaveGame.MsgPrint("Something disrupts your concentration!");
                SaveGame.Energy -= 100;
                SaveGame.TeleportPlayer(20);
            }
            else
            {
                SaveGame.TeleportPlayerTo(j, i);
            }
        }
    }

    protected override string Comment()
    {
        return $"range {(SaveGame.ExperienceLevel < 25 ? 10 : SaveGame.ExperienceLevel + 2)}";
    }
}