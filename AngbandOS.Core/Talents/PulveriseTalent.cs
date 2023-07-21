// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class PulveriseTalent : Talent
{
    private PulveriseTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Pulverise";
    public override void Initialize(int characterClass)
    {
        Level = 11;
        ManaCost = 7;
        BaseFailure = 30;
    }

    public override void Use(SaveGame saveGame)
    {
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<SoundProjectile>(), dir,
            Program.Rng.DiceRoll(8 + ((saveGame.Player.ExperienceLevel - 5) / 4), 8), saveGame.Player.ExperienceLevel > 20 ? ((saveGame.Player.ExperienceLevel - 20) / 8) + 1 : 0);
    }

    protected override string Comment(Player player)
    {
        return $"dam {8 + ((player.ExperienceLevel - 5) / 4)}d8";
        ;
    }
}