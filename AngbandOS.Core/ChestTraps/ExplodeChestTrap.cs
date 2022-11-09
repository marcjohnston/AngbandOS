namespace AngbandOS.Core.ChestTraps
{
    internal class ExplodeChestTrap : BaseChestTrap
    {
        public ExplodeChestTrap(BaseChestTrap? nextTrap = null) : base(nextTrap)
        {
        }
        protected override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("There is a sudden explosion!");
            eventArgs.SaveGame.MsgPrint("Everything inside the chest is destroyed!");
            eventArgs.DestroysContents = true;
            eventArgs.SaveGame.Player.TakeHit(Program.Rng.DiceRoll(5, 8), "an exploding chest");
        }
    }
}
