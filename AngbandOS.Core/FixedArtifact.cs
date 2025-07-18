﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
public class FixedArtifactGameConfiguration
{
    public virtual string Key { get; set; } = null;
}

[Serializable]
internal abstract class FixedArtifact : IGetKey, IToJson
{
    protected readonly Game Game;
    protected FixedArtifact(Game game)
    {
        Game = game;
//        Key = fixedArtifactGameConfiguration.Key ?? fixedArtifactGameConfiguration.GetType().Name;
    }

    public void Bind()
    {
        BaseItemFactory = Game.SingletonRepository.Get<ItemFactory>(BaseItemFactoryName);
    }
    public string ToJson()
    {
        FixedArtifactGameConfiguration gameConfiguration = new FixedArtifactGameConfiguration()
        {
            Key = Key,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    /// <summary>
    /// Represents the quantity of this artifact currently in existence.  
    /// </summary>
    public int CurNum = 0; // TODO: This property should graduate into an ItemFactory as the Count property.

    /// <summary>
    /// Returns the multipler to use when being used to kill a dragon.  The SwordOfLightning returns a 3.  All other weapons return 1.
    /// </summary>
    public virtual int KillDragonMultiplier => 1; // TODO: Move this into the ItemCharacteristics

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
    public abstract string Name { get; } // TODO: This must be used outside of the ItemEnhancement

    /// <summary>
    /// Overrides the BaseItemFactory Cost
    /// </summary>
    public abstract int Cost { get; } // TODO: Need to convert this to an enhancement .. this also doesn't appear to be copied

    /// <summary>
    /// Overrides the BaseItemFactory Cost
    /// </summary>
    public abstract int Dd { get; } // TODO: Need to convert this to an enhancement

    public abstract int Ds { get; } // TODO: Need to convert this to an enhancement

    public virtual bool HasOwnType => false; // TODO: What is this?

    public abstract int Level { get; } // TODO: Need to convert this to an enhancement.  This must be used outside of the ItemEnhancement

    public abstract int Rarity { get; } // TODO: Need to convert this to an enhancement.  This must be used outside of the ItemEnhancement

    public abstract int ToA { get; } // TODO: Need to convert this to an enhancement

    public abstract int ToD { get; } // TODO: Need to convert this to an enhancement

    public abstract int ToH { get; } // TODO: Need to convert this to an enhancement

    public abstract int Weight { get; } // TODO: Need to convert this to an enhancement
}
