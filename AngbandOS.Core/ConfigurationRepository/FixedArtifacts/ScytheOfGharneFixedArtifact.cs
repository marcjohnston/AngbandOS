// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ScytheOfGharneFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private ScytheOfGharneFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(ScythePolearmWeaponItemFactory));
    }


    // G'Harne does Word of Recall
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("Your scythe glows soft white...");
        SaveGame.RunScript(nameof(ToggleRecallScript));
        item.RechargeTimeLeft = 200;
    }
    public string DescribeActivationEffect() => "word of recall every 200 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ForwardSlashSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Scythe of G'harne";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandCold => true;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int Cost => 18000;
    public override int Dd => 5;
    public override bool Dex => true;
    public override int Ds => 3;
    public override bool FreeAct => true;
    public override string FriendlyName => "of G'harne";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override bool Lightsource => true;
    public override int Pval => 3;
    public override int Rarity => 8;
    public override bool ResCold => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override int ToA => 10;
    public override int ToD => 8;
    public override int ToH => 8;
    public override int Weight => 250;
}
