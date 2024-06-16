// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsOfThanosFixedArtifact : FixedArtifact
{
    private SetOfGauntletsOfThanosFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(GauntletGlovesArmorItemFactory);


    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Set of Gauntlets of Thanos";
    public override int Ac => 2;
    public override bool Aggravate => true;
    public override int Cost => 0;
    public override bool IsCursed => true;
    public override int Dd => 1;
    public override bool Dex => true;
    public override bool DreadCurse => true;
    public override int Ds => 1;
    public override string FriendlyName => "of Thanos";
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool ImFire => true;
    public override int Level => 10;
    protected override string? BonusDexterityRollExpression => "2";
    protected override string? BonusStrengthRollExpression => "2";
    public override int Rarity => 20;
    public override bool ResChaos => true;
    public override bool ResDisen => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool ShowMods => true;
    public override bool Str => true;
    public override bool Teleport => true;
    public override int ToA => 0;
    public override int ToD => -12;
    public override int ToH => -11;
    public override int Weight => 25;
}
