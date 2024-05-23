// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlimeMoldJuicePotionItemFactory : PotionItemFactory
{
    private SlimeMoldJuicePotionItemFactory(Game game) : base(game) { } // This object is a singleton

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Slime Mold Juice";

    public override void Bind()
    {
        base.Bind();
        Flavor = Game.SingletonRepository.Get<PotionReadableFlavor>(nameof(IckyGreenPotionReadableFlavor));
    }
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int Cost => 2;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Slime Mold Juice";
    public override int InitialNutritionalValue => 400;
    public override int Weight => 4;
    public override bool Quaff()
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
        PotionItemFactory potion = (PotionItemFactory)itemFactoryWeightedRandom.Choose();
        potion.Quaff();
        return true;
    }

    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
}
