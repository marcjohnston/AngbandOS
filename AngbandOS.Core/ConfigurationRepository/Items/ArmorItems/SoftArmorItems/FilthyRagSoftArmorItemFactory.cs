// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class FilthyRagSoftArmorItemFactory : SoftArmorItemFactory
{
    private FilthyRagSoftArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenParenthesisSymbol>();
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "Filthy Rag";

    public override int Ac => 1;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1;
    public override string FriendlyName => "& Filthy Rag~";
    public override int ToA => -1;
    public override int Weight => 20;
    public override Item CreateItem() => new FilthyRagSoftArmorItem(SaveGame);
}
