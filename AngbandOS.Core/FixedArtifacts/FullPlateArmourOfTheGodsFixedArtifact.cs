// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class FullPlateArmorOfTheGodsFixedArtifact : FixedArtifact
{
    private FullPlateArmorOfTheGodsFixedArtifact(Game game) : base(game) { }
    public override int TreasureRating => 10;

    protected override string BaseItemFactoryName => nameof(FullPlateHardArmorItemFactory);


    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Full Plate Armor of the Gods";
    public override int Ac => 25;
    public override bool Con => true;
    public override int Cost => 50000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "of the Gods";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override string? BonusConstitutionRollExpression => "1";
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResNexus => true;
    public override bool ResSound => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 300;
}
