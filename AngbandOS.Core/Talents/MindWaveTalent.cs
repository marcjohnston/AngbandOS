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
    public override void Initialize(int characterClass)
    {
        Level = 18;
        ManaCost = 10;
        BaseFailure = 45;
    }

    public override void Use()
    {
        SaveGame.MsgPrint("Mind-warping forces emanate from your brain!");
        if (SaveGame.ExperienceLevel < 25)
        {
            SaveGame.Project(0, 2 + (SaveGame.ExperienceLevel / 10), SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel * 3 / 2,
                SaveGame.SingletonRepository.Projectiles.Get<PsiProjectile>(), ProjectionFlag.ProjectKill);
        }
        else
        {
            SaveGame.MindblastMonsters(SaveGame.ExperienceLevel * (((SaveGame.ExperienceLevel - 5) / 10) + 1));
        }
    }

    protected override string Comment()
    {
        return SaveGame.ExperienceLevel < 25 ? $"dam {SaveGame.ExperienceLevel * 3 / 2}" : $"dam {SaveGame.ExperienceLevel * (((SaveGame.ExperienceLevel - 5) / 10) + 1)}";
    }
}