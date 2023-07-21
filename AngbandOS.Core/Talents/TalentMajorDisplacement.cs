// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class TalentMajorDisplacement : Talent
{
    public override string Name => "Major Displacement";
    public override void Initialise(int characterClass)
    {
        Level = 7;
        ManaCost = 6;
        BaseFailure = 35;
    }

    public override void Use(SaveGame saveGame)
    {
        saveGame.TeleportPlayer(saveGame.Player.ExperienceLevel * 5);
        if (saveGame.Player.ExperienceLevel > 29)
        {
            saveGame.BanishMonsters(saveGame.Player.ExperienceLevel);
        }
    }

    protected override string Comment(Player player)
    {
        return $"range {player.ExperienceLevel * 5}";
    }
}