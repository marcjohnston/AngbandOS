// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class NatureMasteryNatureBookItemFactory : NatureBookItemFactory
{
    private NatureMasteryNatureBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "[Nature Mastery]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Nature Mastery]";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int? SubCategory => 1;
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new NatureMasteryNatureBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<NatureSpellStoneToMud>(),
        SaveGame.SingletonRepository.Spells.Get<NatureSpellLightningBolt>(),
        SaveGame.SingletonRepository.Spells.Get<NatureSpellNatureAwareness>(),
        SaveGame.SingletonRepository.Spells.Get<NatureSpellFrostBolt>(),
        SaveGame.SingletonRepository.Spells.Get<NatureSpellRayOfSunlight>(),
        SaveGame.SingletonRepository.Spells.Get<NatureSpellEntangle>(),
        SaveGame.SingletonRepository.Spells.Get<NatureSpellSummonAnimal>(),
        SaveGame.SingletonRepository.Spells.Get<NatureSpellHerbalHealing>()
    };
}
