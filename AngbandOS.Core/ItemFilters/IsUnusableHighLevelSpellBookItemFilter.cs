// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an item filter for spell books that are in the primary or secondary realms.
/// </summary>
[Serializable]
internal class IsUnusableHighLevelSpellBookItemFilter : ItemFilter
{
    private IsUnusableHighLevelSpellBookItemFilter(Game game) : base(game) { } // This object is a singleton.
    public override bool? IsUsableSpellBook => false;
    protected override string[]? AnyMatchingItemFactoryNames => new string[]
    {
        nameof(AzathothChaosBookItemFactory),
        nameof(CeleanoFragmentsTarotBookItemFactory),
        nameof(CthaatAquadingenNatureBookItemFactory),
        nameof(CultesdesGoulesDeathBookItemFactory),
        nameof(DeVermisMysteriisCorporealBookItemFactory),
        nameof(DholChantsLifeBookItemFactory),
        nameof(EltdownShardsTarotBookItemFactory),
        nameof(GharneFragmentsChaosBookItemFactory),
        nameof(LiberIvonisSorceryBookItemFactory),
        nameof(MagicksOfMasteryFolkBookItemFactory),
        nameof(MajorMagicksFolkBookItemFactory),
        nameof(NecronomiconDeathBookItemFactory),
        nameof(PnakoticManuscriptsCorporealBookItemFactory),
        nameof(PonapeScriptureLifeBookItemFactory),
        nameof(RevelationsOfGlaakiNatureBookItemFactory),
        nameof(UnaussprechlichenKultenSorceryBookItemFactory),
    };
}
