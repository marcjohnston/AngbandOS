// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RuinedChestItemFactory : ItemFactoryGameConfiguration
{
    public override bool IsBroken => true;
    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    public override string SymbolBindingKey => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Ruined chest";

    public override string? DescriptionSyntax => "Ruined chest~";
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (75, 1)
    };
    public override string? ItemEnhancementBindingKey => nameof(RuinedChestItemFactoryItemEnhancement);
    public override bool IsSmall => true;
    public override int NumberOfItemsContained => 0;
    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (null, null, new string[] { nameof(SystemScriptsEnum.ChestEnchantmentScript) }),
    };
    public override string ItemClassBindingKey => nameof(ChestsItemClass);
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Chests. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool IsContainer => true;

    public override int PackSort => 36;
}
