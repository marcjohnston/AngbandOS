// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GlaiveOfPainFixedArtifact : FixedArtifact
{
    private GlaiveOfPainFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(GlaivePolearmWeaponItemFactory);


    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ForwardSlashSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Glaive of Pain";
    public override int Ac => 0;
    public override int Cost => 50000;
    public override int Dd => 9;
    public override int Ds => 6;
    public override string FriendlyName => "of Pain";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 0;
    public override int Rarity => 25;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 30;
    public override int ToH => 0;
    public override int Weight => 190;
}
