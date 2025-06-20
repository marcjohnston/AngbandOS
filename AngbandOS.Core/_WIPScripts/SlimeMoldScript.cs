// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SlimeMoldScript : Script, IEatOrQuaffScript
{
    private SlimeMoldScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        // Slime mold juice has a random effect (calling this function again recusively)
        Game.MsgPrint("That tastes awful.");

        // The following potions are not selected as random.  SlimeMold is the potion causing the random.
        //Death = 23,
        //DecCha = 21,
        //DecCon = 20,
        //DecDex = 19,
        //DecInt = 17,
        //DecStr = 16,
        //DecWis = 18,
        //LoseMemories = 13,
        //Ruination = 15,
        //SlimeMold = 2,

        ItemFactoryWeightedRandom itemFactoryWeightedRandom = Game.SingletonRepository.Get<ItemFactoryWeightedRandom>(nameof(SlimeMoldPotionItemFactoryWeightedRandom));
        ItemFactory potion = itemFactoryWeightedRandom.Choose();
        if (potion.QuaffTuple == null)
        {
            throw new Exception($"The {nameof(WeightedRandom<ItemFactoryWeightedRandom>)} choose an item that is not a potion.");
        }
        potion.QuaffTuple.Value.QuaffScript.ExecuteEatOrQuaffScript();
        return new IdentifiedResult(true);
    }
}