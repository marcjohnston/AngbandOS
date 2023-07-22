// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class TelekineticWaveTalent : Talent
{
    private TelekineticWaveTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Telekinetic Wave";
    public override void Initialize(int characterClass)
    {
        Level = 28;
        ManaCost = 20;
        BaseFailure = 45;
    }

    public override void Use()
    {
        SaveGame.MsgPrint("A wave of pure physical force radiates out from your body!");
        SaveGame.Project(0, 3 + (SaveGame.Player.ExperienceLevel / 10), SaveGame.Player.MapY, SaveGame.Player.MapX,
            SaveGame.Player.ExperienceLevel * (SaveGame.Player.ExperienceLevel > 39 ? 4 : 3), SaveGame.SingletonRepository.Projectiles.Get<TelekinesisProjectile>(),
            ProjectionFlag.ProjectKill | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectGrid);
    }

    protected override string Comment()
    {
        return $"dam {SaveGame.Player.ExperienceLevel * (SaveGame.Player.ExperienceLevel > 39 ? 4 : 3)}";
    }
}