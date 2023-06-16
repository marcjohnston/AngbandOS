// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class MartialArtsAttack
{
    public readonly int Chance;
    public readonly int Dd;
    public readonly string Desc;
    public readonly int Ds;
    public readonly int Effect;
    public readonly int MinLevel;

    public MartialArtsAttack(string desc, int minLevel, int chance, int dd, int ds, int effect)
    {
        Desc = desc;
        MinLevel = minLevel;
        Chance = chance;
        Dd = dd;
        Ds = ds;
        Effect = effect;
    }
}