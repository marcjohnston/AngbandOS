// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Turn an item to gold.
/// </summary>
[Serializable]
internal class GetawayEvery35Activation : Activation
{
    private GetawayEvery35Activation(SaveGame saveGame) : base(saveGame) { }

    public override int RandomChance => 5;

    public override string? PreActivationMessage => "Your {0} shimmers...";

    protected override bool OnActivate(Item item)
    {
        switch (SaveGame.DieRoll(13))
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                SaveGame.RunScriptInt(nameof(TeleportSelfScript), 10);
                break;

            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                SaveGame.RunScriptInt(nameof(TeleportSelfScript), 222);
                break;

            case 11:
            case 12:
                SaveGame.RunScript(nameof(CreateStairsScript));
                break;

            default:
                if (SaveGame.GetCheck("Leave this level? "))
                {
                    {
                        SaveGame.DoCmdSaveGame(true);
                    }
                    SaveGame.NewLevelFlag = true;
                    SaveGame.CameFrom = LevelStart.StartRandom;
                }
                break;
        }
        return true;
    }

    public override int RechargeTime() => 35;

    public override int Value => 500;

    public override string Name => "A getaway";
    public override string Frequency => "35";
}
