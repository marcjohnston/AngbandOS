// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal abstract class FixedArtifact : IGetKey, IToJson, IGameSerialize
{
    protected Game Game { get; }
    protected FixedArtifact(Game game)
    {
        Game = game;
    }

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(CurNum), new IntValueGameStateBag(CurNum))
        );
    }
    public void Bind(RestoreGameState? restoreGameState)
    {
        BaseItemFactory = Game.SingletonRepository.Get<ItemFactory>(BaseItemFactoryName);

        if (restoreGameState is not null)
        {
            CurNum = restoreGameState.GetByKey(nameof(CurNum)).GetInt();
        }
    }

    public string ToJson()
    {
        return "";
    }

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the <see cref="FlavorColor"/> and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    public virtual ColorEnum Color { get; set; }

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

    public virtual bool DisableStomp => false;
    public abstract string Name { get; } // TODO: This must be used outside of the ItemEnhancement

    public virtual bool DisableViaEnchantment => false;
    public virtual bool DisableViaRandom => false;

    public abstract int Level { get; } // TODO: Need to convert this to an enhancement.  This must be used outside of the ItemEnhancement

    public abstract int Rarity { get; } // TODO: Need to convert this to an enhancement.  This must be used outside of the ItemEnhancement
}
