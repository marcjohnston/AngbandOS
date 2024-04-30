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
internal abstract class ArtifactBias : IArtifactBias, IGetKey
{
    protected readonly Game Game;
    public string GetKey => Key;

    protected ArtifactBias(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public virtual void Bind() { }

    /// <inheritdoc/>
    public virtual int ImmunityLuckOneInChance => 20;

    /// <inheritdoc/>
    public virtual bool ApplyBonuses(Item item) => false;

    /// <inheritdoc/>
    public virtual bool ApplyRandomResistances(Item item) => false;

    /// <inheritdoc/>
    public virtual bool ApplyMiscPowers(Item item) => false;

    /// <inheritdoc/>
    public virtual bool ApplySlaying(Item item) => false;

    /// <inheritdoc/>
    public virtual Activation GetActivationPowerType(Item item) => null;

    /// <inheritdoc/>
    public virtual int ActivationPowerChance => 101;
}
