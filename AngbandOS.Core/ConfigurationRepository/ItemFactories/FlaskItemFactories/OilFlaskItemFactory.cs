// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OilFlaskItemFactory : FlaskItemFactory
{
    private OilFlaskItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    /// <summary>
    /// Returns true because a flask of oil is valid as fuel for lanterns.
    /// </summary>
    public override bool IsFuelForLantern => true;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Flask of oil";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 3;
    public override int Dd => 2;
    public override int Ds => 6;
    public override string FriendlyName => "& Flask~ of oil";
    public override int LevelNormallyFound => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int InitialTypeSpecificValue => 7500;
    public override int Weight => 10;
    public override Item CreateItem() => new Item(SaveGame, this);
}
