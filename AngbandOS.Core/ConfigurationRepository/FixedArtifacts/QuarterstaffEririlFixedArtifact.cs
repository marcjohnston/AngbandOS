// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class QuarterstaffEririlFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private QuarterstaffEririlFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(HaftedQuarterstaff));
    }


    // Ereril does identify
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your quarterstaff glows yellow...");
        if (!saveGame.IdentifyItem())
        {
            return;
        }
        item.RechargeTimeLeft = 10;
    }
    public string DescribeActivationEffect() => "identify every 10 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(BackSlashSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Quarterstaff 'Eriril'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 20000;
    public override int Dd => 1;
    public override int Ds => 9;
    public override string FriendlyName => "'Eriril'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 18;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override int ToA => 0;
    public override int ToD => 5;
    public override int ToH => 3;
    public override int Weight => 150;
    public override bool Wis => true;
}
