namespace AngbandOS.Core.Scripts;

// Hobbits can cook food
[Serializable]
internal class HobbitRacialPowerScript : Script, IScript
{
    private HobbitRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        ItemFactory foodItemFactory = Game.SingletonRepository.Get<ItemFactory>(nameof(RationFoodItemFactory));
        Item item = foodItemFactory.GenerateItem();
        Game.DropNear(item, null, Game.MapY.IntValue, Game.MapX.IntValue);
        Game.MsgPrint("You cook some food.");
    }
}