// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MasteryChaosBookItemFactory : ChaosBookItemFactory
{
    private MasteryChaosBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.BrightRed;
    public override string Name => "[Chaos Mastery]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Chaos Mastery]";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new Item(SaveGame, this);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellWonder)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellChaosBolt)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellSonicBoom)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellDoomBolt)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellFireBall)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellTeleportOther)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellWordOfDestruction)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellInvokeChaos))
    };
}
