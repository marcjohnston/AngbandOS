// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MartialArtsAttacks;

[Serializable]
internal abstract class MartialArtsAttack : IConfigurationRepository
{
    protected readonly SaveGame SaveGame;

    protected MartialArtsAttack(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    public abstract int Chance { get; }
    public abstract int Dd { get; }
    public abstract string Desc { get; }
    public abstract int Ds { get; }
    public abstract int Effect { get; }
    public abstract int MinLevel { get;  }
    public virtual bool IsDefault => false;
}