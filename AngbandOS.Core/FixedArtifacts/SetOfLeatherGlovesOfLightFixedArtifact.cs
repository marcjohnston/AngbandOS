// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfLeatherGlovesOfLightFixedArtifact : FixedArtifact
{
    private SetOfLeatherGlovesOfLightFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(LeatherGlovesItemFactory);
    protected override string? ActivationName => nameof(MagicMissle2d6Every2DirectionalActivation);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Set of Leather Gloves of Light";
    public override int Ac => 1;
    public override int Cost => 30000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Light";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a set of leather gloves which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int Rarity => 3;
    public override bool ResLight => true;
    public override bool SustCon => true;
    public override int ToA => 10;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 5;
}
