// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interface.Definitions;

[Serializable]
public class MonsterAttackDefinition
{
    public virtual string MethodName { get; set; }
    public virtual string? EffectName { get; set; }
    public virtual int DDice { get; set; }
    public virtual int DSide { get; set; }

    /// <summary>
    /// The constructor to use for Json deserialization.
    /// </summary>
    public MonsterAttackDefinition() { }

    /// <summary>
    /// The constructor to use for gamepacks.
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="effectName"></param>
    /// <param name="dice"></param>
    /// <param name="sides"></param>
    public MonsterAttackDefinition(string methodName, string? effectName, int dice, int sides)
    {
        MethodName = methodName;
        EffectName = effectName;
        DDice = dice;
        DSide = sides;
    }
}
