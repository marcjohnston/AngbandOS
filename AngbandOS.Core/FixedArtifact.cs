// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Diagnostics;

namespace AngbandOS.Core;

[Serializable]
internal abstract class FixedArtifact : IGetKey, IToJson
{
    protected readonly Game Game;
    protected FixedArtifact(Game game)
    {
        Game = game;
    }

    public void Bind()
    {
        BaseItemFactory = Game.SingletonRepository.Get<ItemFactory>(BaseItemFactoryName);

        //// Cut and paste
        //string? property = Game.CutProperty(@$"D:\Programming\AngbandOS\AngbandOS.Core\FixedArtifacts", Key, "public override int ToD => ");
        //if (property is null)
        //    throw new Exception("");
        //MappedItemEnhancement[] allMappedItemEnhancements = Game.SingletonRepository.Get<MappedItemEnhancement>(); // TODO: This is slow
        //MappedItemEnhancement[]? mappedItemEnhancements = allMappedItemEnhancements.Where(_mappedItemEnhancement => (_mappedItemEnhancement.FixedArtifactBindingKeys is not null && _mappedItemEnhancement.FixedArtifactBindingKeys.Contains(GetKey))).ToArray(); // Must match the character class

        //if (mappedItemEnhancements.Length == 0)
        //    throw new Exception("");
        //foreach (MappedItemEnhancement mappedItemEnhancement in mappedItemEnhancements)
        //{
        //    mappedItemEnhancement.Bind();
        //    BaseItemFactory.Bind();
        //    ItemEnhancement itemEnhancement = mappedItemEnhancement.ItemEnhancements[0].GetItemEnhancement();
        //    if ((BaseItemFactory.ItemEnhancement?.BonusDamageRollExpression == null ? 0 : Int32.Parse(BaseItemFactory.ItemEnhancement.BonusDamageRollExpression)) != ToD)
        //        Game.PasteProperty(@$"D:\Programming\AngbandOS\AngbandOS.GamePacks.Cthangband\ItemEnhancements", mappedItemEnhancement.ItemEnhancements[0].GetItemEnhancement()!.GetKey, $"    public override string BonusDamageRollExpression => \"{ToD - (BaseItemFactory.ItemEnhancement?.BonusDamageRollExpression is null ? 0 : Int32.Parse(BaseItemFactory.ItemEnhancement.BonusDamageRollExpression))}\";");
        //    //Debug.Print($"{itemEnhancement.GetKey} public override int DamageSides => {itemEnhancement.DiceSides - BaseItemFactory.ItemEnhancement.DiceSides};");
        //    //Game.PasteProperty(@$"D:\Programming\AngbandOS\AngbandOS.GamePacks.Cthangband\ItemEnhancements", mappedItemEnhancement.ItemEnhancements[0].GetItemEnhancement()!.GetKey, property);
        //}
    }

    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    /// <summary>
    /// Represents the quantity of this artifact currently in existence.  
    /// </summary>
    public int CurNum = 0; // TODO: This property should graduate into an ItemFactory as the Count property.

    protected abstract string BaseItemFactoryName { get; }

    /// <summary>
    /// Returns the item factory that acts as the base item for fixed artifacts of this type.
    /// </summary>
    public ItemFactory BaseItemFactory { get; private set; }

    /// <summary>
    /// Returns a 1-in-chance value of the weapon doing extra vorpal damage.  Does not affect non-vorpal cutting weapons.  Default to a 1-in-6 chance.
    /// </summary>
    public virtual int VorpalExtraDamage1InChance => 6; // TODO: Move this into the ItemCharacteristics

    public virtual bool IsVorpalBlade => false; // TODO: Move this into the ItemCharacteristics

    /// <summary>
    /// Returns a 1-in-chance value of the weapon doing extra vorpal attacks. Does not affect non-vorpal cutting weapons.  Default to a 1-in-4 chance.
    /// </summary>
    public virtual int VorpalExtraAttacks1InChance => 4; // TODO: Move this into the ItemCharacteristics

    public virtual ColorEnum Color => ColorEnum.White; // TODO: This must be used outside of the ItemEnhancement
    public virtual bool DisableStomp => false;
    public abstract string Name { get; } // TODO: This must be used outside of the ItemEnhancement

    public virtual bool HasOwnType => false; // TODO: What is this?

    public abstract int Level { get; } // TODO: Need to convert this to an enhancement.  This must be used outside of the ItemEnhancement

    public abstract int Rarity { get; } // TODO: Need to convert this to an enhancement.  This must be used outside of the ItemEnhancement
}
