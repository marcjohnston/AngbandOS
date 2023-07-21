// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class DominationTalent : Talent
{
    private DominationTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Domination";
    public override void Initialize(int characterClass)
    {
        Level = 9;
        ManaCost = 7;
        BaseFailure = 50;
    }

    public override void Use(SaveGame saveGame)
    {
        if (saveGame.Player.ExperienceLevel < 30)
        {
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<DominationProjectile>(), dir, saveGame.Player.ExperienceLevel, 0);
        }
        else
        {
            saveGame.CharmMonsters(saveGame.Player.ExperienceLevel * 2);
        }
    }

    protected override string Comment(Player player)
    {
        return string.Empty;
    }
}