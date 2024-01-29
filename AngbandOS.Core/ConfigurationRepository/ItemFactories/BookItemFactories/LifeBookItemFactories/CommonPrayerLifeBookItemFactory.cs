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
    private CommonPrayerLifeBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "[Book of Common Prayer]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Book of Common Prayer]";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new Item(SaveGame, this);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(LifeSpellDetectEvil)),
        SaveGame.SingletonRepository.Spells.Get(nameof(LifeSpellCureLightWounds)),
        SaveGame.SingletonRepository.Spells.Get(nameof(LifeSpellBless)),
        SaveGame.SingletonRepository.Spells.Get(nameof(LifeSpellRemoveFear)),
        SaveGame.SingletonRepository.Spells.Get(nameof(LifeSpellCallLight)),
        SaveGame.SingletonRepository.Spells.Get(nameof(LifeSpellDetectTrapsAndSecretDoors)),
        SaveGame.SingletonRepository.Spells.Get(nameof(LifeSpellCureMediumWounds)),
        SaveGame.SingletonRepository.Spells.Get(nameof(LifeSpellSatisfyHunger))
   };

}
