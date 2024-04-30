// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal abstract class AttackEffect : IGetKey
{
    protected readonly Game Game;
    protected AttackEffect(Game game)
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

    public string GetKey => Key;
    public virtual void Bind() { }

    public abstract string Description { get; }
    public abstract int Power { get; }
    public abstract void ApplyToPlayer(int monsterLevel, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked);

    /// <summary>
    /// Apply the attack to another monster.  Does nothing by default.
    /// </summary>
    public virtual void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked) { }
}