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

    public override void Use(SaveGame saveGame)
    {
        saveGame.MsgPrint("Mind-warping forces emanate from your brain!");
        if (saveGame.Player.ExperienceLevel < 25)
        {
            saveGame.Project(0, 2 + (saveGame.Player.ExperienceLevel / 10), saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.ExperienceLevel * 3 / 2,
                saveGame.SingletonRepository.Projectiles.Get<PsiProjectile>(), ProjectionFlag.ProjectKill);
        }
        else
        {
            saveGame.MindblastMonsters(saveGame.Player.ExperienceLevel * (((saveGame.Player.ExperienceLevel - 5) / 10) + 1));
        }
    }

    protected override string Comment(Player player)
    {
        return player.ExperienceLevel < 25 ? $"dam {player.ExperienceLevel * 3 / 2}" : $"dam {player.ExperienceLevel * (((player.ExperienceLevel - 5) / 10) + 1)}";
    }
}