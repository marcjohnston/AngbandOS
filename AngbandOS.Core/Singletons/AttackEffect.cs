// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class AttackEffect : IGetKey, IGameSerialize
{
    protected Game Game { get; }
    protected AttackEffect(Game game)
    {
        Game = game;
    }

    public virtual DictionaryGameStateBag? Serialize(SaveGameState saveGameState) => null;

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState) { }

    public abstract string Description { get; }
    public abstract int Power { get; }
    public abstract void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked);

    /// <summary>
    /// Apply the attack to another monster.  Does nothing by default.
    /// </summary>
    public virtual void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked) { }
}