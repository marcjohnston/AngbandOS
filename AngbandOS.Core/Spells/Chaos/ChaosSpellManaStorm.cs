// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellManaStorm : Spell
{
    private ChaosSpellManaStorm(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ManaProjectile>(), dir, 300 + (SaveGame.Player.Level * 2), 4);
    }

    public override void CastFailed()
    {
        DoWildChaoticMagic(29);
    }

    public override string Name => "Mana Storm";
    
    protected override string? Info()
    {
        return $"dam {300 + (SaveGame.Player.Level * 2)}";
    }
}