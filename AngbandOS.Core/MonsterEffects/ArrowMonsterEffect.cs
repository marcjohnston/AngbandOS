// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class ArrowMonsterEffect : MonsterEffect
{
    private ArrowMonsterEffect(Game game) : base(game) {  } // This object is a singleton.

    protected override IdentifiedResultEnum Apply(int who, Monster mPtr, int dam, int r)
    {
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        if (seen)
        {
            obvious = true;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, null, null, 0);
        return obvious ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}
