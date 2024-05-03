// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CommonPrayerLifeBookItemFactory : LifeBookItemFactory
{
    private CommonPrayerLifeBookItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "[Book of Common Prayer]";

    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Book of Common Prayer]";
    public override int LevelNormallyFound => 10;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new Item(Game, this);

    protected override string[] SpellNames => new string[]
    {
        nameof(LifeSpellDetectEvil),
        nameof(LifeSpellCureLightWounds),
        nameof(LifeSpellBless),
        nameof(LifeSpellRemoveFear),
        nameof(LifeSpellCallLight),
        nameof(LifeSpellDetectTrapsAndSecretDoors),
        nameof(LifeSpellCureMediumWounds),
        nameof(LifeSpellSatisfyHunger)
   };

}
