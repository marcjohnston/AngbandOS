// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ConjuringsTricksTarotBookItemFactory : TarotBookItemFactory
{
    private ConjuringsTricksTarotBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.BrightPink;
    public override string Name => "[Conjurings  Tricks]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Conjurings & Tricks]";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new Item(SaveGame, this);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellPhaseDoor)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellMindBlast)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellTarotDraw)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellResetRecall)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellTeleport)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellDimensionDoor)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellAstralSpying)),
        SaveGame.SingletonRepository.Spells.Get(nameof(TarotSpellTeleportAway))
    };
}