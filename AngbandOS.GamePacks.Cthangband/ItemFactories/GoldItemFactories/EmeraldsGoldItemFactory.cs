// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class EmeraldsGoldItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(DollarSignSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "emeralds";

    public override string InitialGoldPiecesRollExpression => "2d32*4";
    public override int LevelNormallyFound => 1;
    public override string ItemClassBindingKey => nameof(GoldItemClass);
    public override int PackSort => 0;
    public override bool IsIgnoredByMonsters => true;
}
