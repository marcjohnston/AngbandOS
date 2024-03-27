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
        if (Game.ExperienceLevel.Value < 25)
        {
            Game.Project(0, 2 + (Game.ExperienceLevel.Value / 10), Game.MapY.Value, Game.MapX.Value, Game.ExperienceLevel.Value * 3 / 2,
                Game.SingletonRepository.Projectiles.Get(nameof(PsiProjectile)), ProjectionFlag.ProjectKill);
        }
        else
        {
            Game.MindblastMonsters(Game.ExperienceLevel.Value * (((Game.ExperienceLevel.Value - 5) / 10) + 1));
        }
    }

    protected override string Comment()
    {
        return Game.ExperienceLevel.Value < 25 ? $"dam {Game.ExperienceLevel.Value * 3 / 2}" : $"dam {Game.ExperienceLevel.Value * (((Game.ExperienceLevel.Value - 5) / 10) + 1)}";
    }
}