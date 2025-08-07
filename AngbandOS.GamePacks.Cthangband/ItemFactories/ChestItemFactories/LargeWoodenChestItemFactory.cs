// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeWoodenChestItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Large wooden chest";

    public override int DamageDice => 2;
    public override int DamageSides => 5;
    public override string? DescriptionSyntax => "Large wooden chest~";
    public override int LevelNormallyFound => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (15, 1)
    };
    public override string? ItemEnhancementBindingKey => nameof(LargeWoodenChestItemFactoryItemEnhancement);
    public override bool IsSmall => false;
    public override int NumberOfItemsContained => 2;
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
