// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SmallMetalShieldVitriolFixedArtifact : FixedArtifact
{
    private SmallMetalShieldVitriolFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(SmallMetalShieldArmorItemFactory);

    public override void ApplyResistances(Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(22) + 16);
    }

    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Small Metal Shield 'Vitriol'";
    public override int Ac => 3;
    public override bool Con => true;
    public override int Cost => 60000;
    public override int Dd => 1;
    public override int Ds => 2;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Vitriol'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override int Level => 30;
    public override int Pval => 4;
    public override int Rarity => 6;
    public override bool ResChaos => true;
    public override bool ResSound => true;
    public override bool Str => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 65;
}
