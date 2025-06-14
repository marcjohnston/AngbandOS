// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SpearGaeBulgFixedArtifact : FixedArtifact
{
    private SpearGaeBulgFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(SpearPolearmWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Spear 'Gae Bulg'";
    public override int Ac => 0;
    public override bool BrandCold => true;
    public override int Cost => 30000;
    public override int Dd => 1;
    public override int Ds => 6;
    public override string FriendlyName => "'Gae Bulg'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override int Level => 15;
    protected override string? BonusInfravisionRollExpression => "3";
    protected override string? BonusSpeedRollExpression => "3";
    protected override string? BonusStealthRollExpression => "3";
    public override int Rarity => 12;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayUndead => true;
    public override bool Speed => true;
    public override bool Stealth => true;
    public override int ToA => 0;
    public override int ToD => 13;
    public override int ToH => 11;
    public override int Weight => 50;
}
