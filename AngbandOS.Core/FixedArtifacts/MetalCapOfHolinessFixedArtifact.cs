// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MetalCapOfHolinessFixedArtifact : FixedArtifact
{
    private MetalCapOfHolinessFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(MetalCapHelmItemFactory);


    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Metal Cap of Holiness";
    public override int Ac => 3;
    public override bool Cha => true;
    public override int Cost => 22000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "of Holiness";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    protected override string? BonusCharismaRollExpression => "3";
    protected override string? BonusWisdomRollExpression => "3";
    public override int Rarity => 2;
    public override int ToA => 12;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 20;
    public override bool Wis => true;
}
