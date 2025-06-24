// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GetawayScript : Script, IActivateItemScript
{
    private GetawayScript(Game game) : base(game) { }

    public UsedResultEnum ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        switch (Game.DieRoll(13))
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                Game.RunScript(nameof(TeleportSelf10TeleportSelfScript));
                break;

            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                Game.RunScript(nameof(TeleportSelf222TeleportSelfScript));
                break;

            case 11:
            case 12:
                Game.RunScript(nameof(CreateStairsScript));
                break;

            default:
                if (Game.GetCheck("Leave this level? "))
                {
                    {
                        Game.DoCmdSaveGame(true);
                    }
                    Game.NewLevelFlag = true;
                    Game.CameFrom = LevelStartEnum.StartRandom;
                }
                break;
        }
        return UsedResultEnum.True;
    }
}
