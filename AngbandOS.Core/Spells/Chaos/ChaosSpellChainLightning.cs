// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellChainLightning : Spell
{
    private ChaosSpellChainLightning(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        for (int dir = 0; dir <= 9; dir++)
        {
            SaveGame.FireBeam(SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), dir, Program.Rng.DiceRoll(5 + (SaveGame.Player.Level / 10), 8));
        }
    }

    public override void CastFailed()
    {
        DoWildChaoticMagic(17);
    }

    public override string Name => "Chain Lightning";
    
    protected override string? Info()
    {
        return $"dam {5 + (SaveGame.Player.Level / 10)}d8";
    }
}