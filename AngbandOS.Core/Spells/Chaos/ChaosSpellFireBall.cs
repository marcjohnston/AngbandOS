// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellFireBall : Spell
{
    private ChaosSpellFireBall(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, 55 + SaveGame.Player.Level, 2);
    }

    public override void CastFailed()
    {
        DoWildChaoticMagic(12);
    }

    public override string Name => "Fire Ball";
    
    protected override string? Info()
    {
        return $"dam {55 + SaveGame.Player.Level}";
    }
}