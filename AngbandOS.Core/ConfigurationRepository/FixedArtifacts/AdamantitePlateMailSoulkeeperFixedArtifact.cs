// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class AdamantitePlateMailSoulkeeperFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private AdamantitePlateMailSoulkeeperFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<AdamantitePlateMailHardArmorItemFactory>();
    }


    // Soulkeeper heals you a lot
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your armor glows a bright white...");
        saveGame.MsgPrint("You feel much better...");
        saveGame.RestoreHealth(1000);
        saveGame.TimedBleeding.ResetTimer();
        item.RechargeTimeLeft = 888;
    }
    public string DescribeActivationEffect() => "heal (1000) every 888 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override string Name => "The Adamantite Plate Mail 'Soulkeeper'";
    public override int Ac => 40;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 300000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "'Soulkeeper'";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 75;
    public override int Pval => 2;
    public override int Rarity => 9;
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool SustCon => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => -4;
    public override int Weight => 420;
}