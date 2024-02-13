// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Sorcery;

[Serializable]
internal class SorcerySpellDimensionDoor : Spell
{
    private SorcerySpellDimensionDoor(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.MsgPrint("You open a dimensional gate. Choose a destination.");
        if (!SaveGame.TgtPt(out int ii, out int ij))
        {
            return;
        }
        SaveGame.Energy -= 60 - SaveGame.ExperienceLevel;
        if (!SaveGame.GridPassableNoCreature(ij, ii) || SaveGame.Grid[ij][ii].TileFlags.IsSet(GridTile.InVault) ||
            SaveGame.Distance(ij, ii, SaveGame.MapY, SaveGame.MapX) > SaveGame.ExperienceLevel + 2 ||
            SaveGame.RandomLessThan(SaveGame.ExperienceLevel * SaveGame.ExperienceLevel / 2) == 0)
        {
            SaveGame.MsgPrint("You fail to exit the astral plane correctly!");
            SaveGame.Energy -= 100;
            SaveGame.RunScriptInt(nameof(TeleportSelfScript), 10);
        }
        else
        {
            SaveGame.TeleportPlayerTo(ij, ii);
        }
    }

    public override string Name => "Dimension Door";

    protected override string LearnedDetails => $"range {SaveGame.ExperienceLevel + 2}";
}