// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PikeOfTepesFixedArtifact : FixedArtifact
{
    private PikeOfTepesFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(PikePolearmWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Pike of Tepes";
    public override int Ac => 0;
    public override bool BrandCold => true;
    public override bool BrandFire => true;
    public override int Cost => 32000;
    public override int Dd => 2;
    public override int Ds => 5;
    public override string FriendlyName => "of Tepes";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 2;
    public override int Rarity => 15;
    public override bool ResCold => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayGiant => true;
    public override bool SlayTroll => true;
    public override bool SlowDigest => true;
    public override bool SustInt => true;
    public override int ToA => 10;
    public override int ToD => 12;
    public override int ToH => 10;
    public override int Weight => 160;
}
