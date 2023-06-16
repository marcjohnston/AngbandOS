namespace AngbandOS.Core.Commands;

/// <summary>
/// Use a rod from the inventory or ground
/// </summary>
/// <param name="itemIndex"> The inventory index of the item to be used </param>
[Serializable]
internal class ZapRodGameCommand : GameCommand
{
    private ZapRodGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'z';

    public override bool Execute()
    {
        SaveGame.DoCmdZapRod();
        return false;
    }
}
