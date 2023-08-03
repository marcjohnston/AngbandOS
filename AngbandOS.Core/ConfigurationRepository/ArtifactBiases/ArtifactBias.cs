// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

/// <summary>
/// Represents the bias used when applying special abilities to an artifact.
/// </summary>
[Serializable]
internal abstract class ArtifactBias : IArtifactBias, IConfigurationRepository
{
    protected readonly SaveGame SaveGame;

    protected ArtifactBias(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    /// <inheritdoc/>
    public virtual int ImmunityLuckOneInChance => 20;

    /// <inheritdoc/>
    public virtual bool ApplyBonuses(Item item)
    {
        return false;
    }

    /// <inheritdoc/>
    public virtual bool ApplyRandomResistances(Item item)
    {
        return false;
    }

    /// <inheritdoc/>
    public virtual bool ApplyMiscPowers(Item item)
    {
        return false;
    }

    /// <inheritdoc/>
    public virtual bool ApplySlaying(Item item)
    {
        return false;
    }

    /// <inheritdoc/>
    public virtual Activation GetActivationPowerType(Item item)
    {
        return null;
    }

    /// <inheritdoc/>
    public virtual int ActivationPowerChance => 101;
}
