// AngbandOS: 2022 Marc Johnston
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

    public override void Use(SaveGame saveGame)
    {
        if (saveGame.Player.ExperienceLevel < 25)
        {
            saveGame.TeleportPlayer(10);
        }
        else
        {
            saveGame.MsgPrint("Choose a destination.");
            if (!saveGame.TgtPt(out int i, out int j))
            {
                return;
            }
            saveGame.Player.Energy -= 60 - saveGame.Player.ExperienceLevel;
            if (!saveGame.Level.GridPassableNoCreature(j, i) || saveGame.Level.Grid[j][i].TileFlags.IsSet(GridTile.InVault) ||
                saveGame.Level.Grid[j][i].FeatureType.Name != "Water" ||
                saveGame.Level.Distance(j, i, saveGame.Player.MapY, saveGame.Player.MapX) > saveGame.Player.ExperienceLevel + 2 ||
                Program.Rng.RandomLessThan(saveGame.Player.ExperienceLevel * saveGame.Player.ExperienceLevel / 2) == 0)
            {
                saveGame.MsgPrint("Something disrupts your concentration!");
                saveGame.Player.Energy -= 100;
                saveGame.TeleportPlayer(20);
            }
            else
            {
                saveGame.TeleportPlayerTo(j, i);
            }
        }
    }

    protected override string Comment(Player player)
    {
        return $"range {(player.ExperienceLevel < 25 ? 10 : player.ExperienceLevel + 2)}";
    }
}