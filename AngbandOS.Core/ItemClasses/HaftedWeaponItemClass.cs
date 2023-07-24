// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ItemClass
{
    protected readonly SaveGame SaveGame;
    protected ItemClass(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    public abstract string Description { get; }
}

[Serializable]
internal class HaftedWeaponsItemClass : ItemClass
{
    private HaftedWeaponsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Hafted Weapons";
}

[Serializable]
internal class PolearmsItemClass : ItemClass
{
    private PolearmsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Polearms";
}

[Serializable]
internal class SwordsItemClass : ItemClass
{
    private SwordsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Swords";
}

[Serializable]
internal class BowsItemClass : ItemClass
{
    private BowsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Bows";
}

[Serializable]
internal class ArrowsItemClass : ItemClass
{
    private ArrowsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Arrows";
}

[Serializable]
internal class BoltsItemClass : ItemClass
{
    private BoltsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Bolts";
}

[Serializable]
internal class ShotsItemClass : ItemClass
{
    private ShotsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Shots";
}

[Serializable]
internal class DiggersItemClass : ItemClass
{
    private DiggersItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Diggers";
}

[Serializable]
internal class LightSourcesItemClass : ItemClass
{
    private LightSourcesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Light Sources";
}

[Serializable]
internal class ChestsItemClass : ItemClass
{
    private ChestsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Chests";
}

[Serializable]
internal class SoftArmorsItemClass : ItemClass
{
    private SoftArmorsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Soft Armours";
}

[Serializable]
internal class HardArmorsItemClass : ItemClass
{
    private HardArmorsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Hard Armours";
}

[Serializable]
internal class DragonScaleMailsItemClass : ItemClass
{
    private DragonScaleMailsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Dragon Scale Mails";
}

[Serializable]
internal class CloaksItemClass : ItemClass
{
    private CloaksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Cloaks";
}

[Serializable]
internal class ShieldsItemClass : ItemClass
{
    private ShieldsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Shields";
}

[Serializable]
internal class CrownsItemClass : ItemClass
{
    private CrownsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Crowns";
}

[Serializable]
internal class HelmsItemClass : ItemClass
{
    private HelmsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Helms";
}

[Serializable]
internal class GlovesItemClass : ItemClass
{
    private GlovesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Gloves";
}

[Serializable]
internal class BootsItemClass : ItemClass
{
    private BootsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Boots";
}

[Serializable]
internal class AmuletsItemClass : ItemClass
{
    private AmuletsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Amulets";
}

[Serializable]
internal class PotionsItemClass : ItemClass
{
    private PotionsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Potions";
}

[Serializable]
internal class RingsItemClass : ItemClass
{
    private RingsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Rings";
}

[Serializable]
internal class RodsItemClass : ItemClass
{
    private RodsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Rods";
}

[Serializable]
internal class ScrollsItemClass : ItemClass
{
    private ScrollsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Scrolls";
}

[Serializable]
internal class StaffsItemClass : ItemClass
{
    private StaffsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Staffs";
}

[Serializable]
internal class WandsItemClass : ItemClass
{
    private WandsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Wands";
}

[Serializable]
internal class ChaosSpellBooksItemClass : ItemClass
{
    private ChaosSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Chaos Spellbooks";
}

[Serializable]
internal class CorporealSpellBooksItemClass : ItemClass
{
    private CorporealSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Corporeal Spellbooks";
}

[Serializable]
internal class DeathSpellBooksItemClass : ItemClass
{
    private DeathSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Death Spellbooks";
}

[Serializable]
internal class FolkSpellBooksItemClass : ItemClass
{
    private FolkSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Folk Spellbooks";
}

[Serializable]
internal class LifeSpellBooksItemClass : ItemClass
{
    private LifeSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Life Spellbooks";
}

[Serializable]
internal class NatureSpellBooksItemClass : ItemClass
{
    private NatureSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Nature Spellbooks";
}

[Serializable]
internal class SorcerySpellBooksItemClass : ItemClass
{
    private SorcerySpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Sorcery Spellbooks";
}

[Serializable]
internal class TarotSpellBooksItemClass : ItemClass
{
    private TarotSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Tarot Spellbooks";
}

[Serializable]
internal class BottlesItemClass : ItemClass
{
    private BottlesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Bottles";
}

[Serializable]
internal class FlasksItemClass : ItemClass
{
    private FlasksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Flasks";
}

[Serializable]
internal class FoodItemClass : ItemClass
{
    private FoodItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Food";
}

[Serializable]
internal class JunkItemClass : ItemClass
{
    private JunkItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Junk";
}

[Serializable]
internal class SkeletonsItemClass : ItemClass
{
    private SkeletonsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Skeletons";
}

[Serializable]
internal class SpikesItemClass : ItemClass
{
    private SpikesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Spikes";
}

[Serializable]
internal class GoldItemClass : ItemClass
{
    private GoldItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Gold";
}
