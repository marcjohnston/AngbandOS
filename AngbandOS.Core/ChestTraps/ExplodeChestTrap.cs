namespace AngbandOS.Core.ChestTraps;

internal class ExplodeChestTrap : BaseChestTrap
{
    public override void Activate(ActivateChestTrapEventArgs eventArgs)
    {
        eventArgs.SaveGame.MsgPrint("There is a sudden explosion!");
        eventArgs.SaveGame.Player.TakeHit(Program.Rng.DiceRoll(5, 8), "an exploding chest");
        eventArgs.DestroysContents = true;
    }

    public override string Description => "(Explosion Device)";
}
