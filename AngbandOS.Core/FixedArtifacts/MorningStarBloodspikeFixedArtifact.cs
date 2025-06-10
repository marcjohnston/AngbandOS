// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MorningStarBloodspikeFixedArtifact : FixedArtifact
{
    private MorningStarBloodspikeFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(MorningStarHaftedWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "The Morning Star 'Bloodspike'";
    public override int Ac => 0;
    public override int Cost => 30000;
    public override int Dd => 2;
    public override int Ds => 6;
    public override string FriendlyName => "'Bloodspike'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    protected override string? BonusStrengthRollExpression => "4";
    public override int Rarity => 30;
    public override bool ResNexus => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 22;
    public override int ToH => 8;
    public override int Weight => 150;
}
