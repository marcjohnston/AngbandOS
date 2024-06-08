// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MaceThunderFixedArtifact : FixedArtifact
{
    private MaceThunderFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(MaceHaftedWeaponItemFactory);

    // Thunder does haste
    protected override string? ActivationName => nameof(Speed20p1d20Every250Activation);

    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "The Mace 'Thunder'";
    public override int Ac => 0;
    public override bool BrandElec => true;
    public override int Cost => 50000;
    public override int Dd => 3;
    public override int Ds => 4;
    public override string FriendlyName => "'Thunder'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImElec => true;
    public override bool KillDragon => true;
    public override int Level => 20;
    public override int InitialTypeSpecificValue => 0;
    public override int Rarity => 15;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 12;
    public override int ToH => 12;
    public override int Weight => 200;
}
