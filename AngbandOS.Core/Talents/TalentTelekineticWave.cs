// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class TalentTelekineticWave : Talent
{
    public override string Name => "Telekinetic Wave";
    public override void Initialise(int characterClass)
    {
        Level = 28;
        ManaCost = 20;
        BaseFailure = 45;
    }

    public override void Use(SaveGame saveGame)
    {
        saveGame.MsgPrint("A wave of pure physical force radiates out from your body!");
        saveGame.Project(0, 3 + (saveGame.Player.ExperienceLevel / 10), saveGame.Player.MapY, saveGame.Player.MapX,
            saveGame.Player.ExperienceLevel * (saveGame.Player.ExperienceLevel > 39 ? 4 : 3), saveGame.SingletonRepository.Projectiles.Get<TelekinesisProjectile>(),
            ProjectionFlag.ProjectKill | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectGrid);
    }

    protected override string Comment(Player player)
    {
        return $"dam {player.ExperienceLevel * (player.ExperienceLevel > 39 ? 4 : 3)}";
    }
}