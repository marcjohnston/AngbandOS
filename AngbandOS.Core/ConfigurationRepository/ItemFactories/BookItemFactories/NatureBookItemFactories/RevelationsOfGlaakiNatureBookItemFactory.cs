// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RevelationsOfGlaakiNatureBookItemFactory : NatureBookItemFactory
{
    private RevelationsOfGlaakiNatureBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "[Revelations of Glaaki]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 25000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Revelations of Glaaki]";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new Item(SaveGame, this);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellDoorCreation)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellStairBuilding)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellStoneSkin)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellResistanceTrue)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellAnimalFriendship)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellStoneTell)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellWallOfStone)),
        SaveGame.SingletonRepository.Spells.Get(nameof(NatureSpellProtectFromCorrosion))
    };
}
