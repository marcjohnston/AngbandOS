// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

public class MonsterAttackDefinition
{
    public string MethodName { get; set; }
    public string? EffectName { get; set; }
    public int DDice { get; set; }
    public int DSide { get; set; }

    public MonsterAttackDefinition() { }
    public MonsterAttackDefinition(string methodName, string? effectName, int dice, int sides)
    {
        MethodName = methodName; 
        EffectName = effectName; 
        DDice = dice; 
        DSide = sides;
    }
}