// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterRaceFilters;

internal class AnyBreathingDragonMonsterRaceFilter : MonsterRaceFilter
{
    private AnyBreathingDragonMonsterRaceFilter(Game game) : base(game) { } // This object is a singleton.

    public override string[]? AnyMonsterSpellBindingKeys => new string[] 
    { 
        nameof(AcidBreathProjectileMonsterSpell), 
        nameof(LightningBreathProjectileMonsterSpell), 
        nameof(FireBreathProjectileMonsterSpell), 
        nameof(ColdBreathProjectileMonsterSpell), 
        nameof(PoisonBreathProjectileMonsterSpell)
    };
    public override string[]? AnySymbolBindingKeys => new string[] { nameof(UpperDSymbol), nameof(LowerDSymbol) };
}
