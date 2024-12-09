// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsIronfistFixedArtifact : FixedArtifact
{
    private SetOfGauntletsIronfistFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(GauntletGlovesItemFactory);
    protected override string? ActivationName => nameof(BoltOfFire9d8Every1d8p8DirectionalActivation);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Set of Gauntlets 'Ironfist'";
    public override int Ac => 2;
    public override int Cost => 15000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "'Ironfist'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Rarity => 20;
    public override bool ResFire => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 25;
}
