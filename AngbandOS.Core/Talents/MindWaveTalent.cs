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
    private MindWaveTalent(Game game) : base(game) { }
    public override string Name => "Mind Wave";
    public override int Level => 18;
    public override int ManaCost => 10;
    public override int BaseFailure => 45;

    public override void Use()
    {
        Game.MsgPrint("Mind-warping forces emanate from your brain!");
        if (Game.ExperienceLevel.IntValue < 25)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PsiProjectile));
            projectile.Fire(0, 2 + (Game.ExperienceLevel.IntValue / 10), Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue * 3 / 2, ProjectionFlag.ProjectKill);
        }
        else
        {
            Game.MindblastMonsters(Game.ExperienceLevel.IntValue * (((Game.ExperienceLevel.IntValue - 5) / 10) + 1));
        }
    }

    protected override string Comment()
    {
        return Game.ExperienceLevel.IntValue < 25 ? $"dam {Game.ExperienceLevel.IntValue * 3 / 2}" : $"dam {Game.ExperienceLevel.IntValue * (((Game.ExperienceLevel.IntValue - 5) / 10) + 1)}";
    }
}