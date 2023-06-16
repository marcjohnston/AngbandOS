// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class MonsterAttack
{
    public int DDice;
    public int DSide;
    public BaseAttackEffect? Effect;
    public BaseAttackType Method;

    public MonsterAttack(BaseAttackType method, BaseAttackEffect? effect, int dice, int sides)
    {
        Method = method;
        Effect = effect;
        DDice = dice;
        DSide = sides;
    }

    public override string ToString()
    {
        return $"{Method} to {Effect} ({DDice}d{DSide})";
    }
}