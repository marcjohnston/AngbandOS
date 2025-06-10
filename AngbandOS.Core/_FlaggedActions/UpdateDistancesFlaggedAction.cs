// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateDistancesFlaggedAction : FlaggedAction
{
    private UpdateDistancesFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        for (int i = 1; i < Game.MonsterMax; i++)
        {
            Monster mPtr = Game.Monsters[i];
            if (mPtr.Race == null)
            {
                continue;
            }
            Game.UpdateMonsterVisibility(i, true);
        }
    }
}