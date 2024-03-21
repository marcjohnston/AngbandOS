// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class MindWaveTalent : Talent
{
    private MindWaveTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Mind Wave";
    public override int Level => 18;
    public override int ManaCost => 10;
    public override int BaseFailure => 45;

    public override void Use()
    {
        SaveGame.MsgPrint("Mind-warping forces emanate from your brain!");
        if (SaveGame.ExperienceLevel.Value < 25)
        {
            SaveGame.Project(0, 2 + (SaveGame.ExperienceLevel.Value / 10), SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel.Value * 3 / 2,
                SaveGame.SingletonRepository.Projectiles.Get(nameof(PsiProjectile)), ProjectionFlag.ProjectKill);
        }
        else
        {
            SaveGame.MindblastMonsters(SaveGame.ExperienceLevel.Value * (((SaveGame.ExperienceLevel.Value - 5) / 10) + 1));
        }
    }

    protected override string Comment()
    {
        return SaveGame.ExperienceLevel.Value < 25 ? $"dam {SaveGame.ExperienceLevel.Value * 3 / 2}" : $"dam {SaveGame.ExperienceLevel.Value * (((SaveGame.ExperienceLevel.Value - 5) / 10) + 1)}";
    }
}