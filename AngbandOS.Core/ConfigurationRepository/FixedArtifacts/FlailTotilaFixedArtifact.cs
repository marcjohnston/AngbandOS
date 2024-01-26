// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class FlailTotilaFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private FlailTotilaFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(HaftedFlail));
    }


    // Totila does confusion
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your flail glows in scintillating colors...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.ConfuseMonster(dir, 20);
        item.RechargeTimeLeft = 15;
    }
    public string DescribeActivationEffect() => "confuse monster every 15 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(BackSlashSymbol));
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "The Flail 'Totila'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandFire => true;
    public override int Cost => 55000;
    public override int Dd => 3;
    public override int Ds => 6;
    public override string FriendlyName => "'Totila'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 2;
    public override int Rarity => 8;
    public override bool ResConf => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool Stealth => true;
    public override int ToA => 0;
    public override int ToD => 8;
    public override int ToH => 6;
    public override int Weight => 150;
}
