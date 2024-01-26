// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GreatAxeOfTheTrollsFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private GreatAxeOfTheTrollsFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(GreatAxePolearmWeaponItemFactory));
    }


    // Trolls does mass carnage
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your axe lets out a long, shrill note...");
        saveGame.MassCarnage(true);
        item.RechargeTimeLeft = 1000;
    }
    public string DescribeActivationEffect() => "mass carnage every 1000 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ForwardSlashSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Great Axe of the Trolls";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Blessed => true;
    public override bool BrandCold => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 200000;
    public override int Dd => 4;
    public override bool Dex => true;
    public override int Ds => 4;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Trolls";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool Int => true;
    public override int Level => 30;
    public override int Pval => 2;
    public override int Rarity => 120;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
    public override int ToA => 8;
    public override int ToD => 18;
    public override int ToH => 15;
    public override int Weight => 230;
    public override bool Wis => true;
}
