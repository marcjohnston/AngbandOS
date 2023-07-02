// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class GharneFragmentsChaosBookItemFactory : ChaosBookItemFactory
{
    private GharneFragmentsChaosBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<QuestionMarkSymbol>();
    public override Colour Colour => Colour.Red;
    public override string Name => "[G'harne Fragments]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 25000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[G'harne Fragments]";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;

    public override int Weight => 30;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new GharneFragmentsChaosBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<ChaosSpellPolymorphOther>(),
        SaveGame.SingletonRepository.Spells.Get<ChaosSpellChainLightning>(),
        SaveGame.SingletonRepository.Spells.Get<ChaosSpellArcaneBinding>(),
        SaveGame.SingletonRepository.Spells.Get<ChaosSpellDisintegrate>(),
        SaveGame.SingletonRepository.Spells.Get<ChaosSpellAlterReality>(),
        SaveGame.SingletonRepository.Spells.Get<ChaosSpellPolymorphSelf>(),
        SaveGame.SingletonRepository.Spells.Get<ChaosSpellChaosBranding>(),
        SaveGame.SingletonRepository.Spells.Get<ChaosSpellSummonDemon>()
    };
}
