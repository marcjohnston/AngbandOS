// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordOfTheDawnFixedArtifact : FixedArtifact
{
    private LongSwordOfTheDawnFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(LongSwordWeaponItemFactory);

    // Dawn Sword summons a reaver
    protected override string? ActivationName => nameof(SummonReaverEvery500p1d500Activation);

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Long Sword of the Dawn";
    public override int Ac => 0;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int Cost => 250000;
    public override int TreasureRating => 20;
    public override int Dd => 3;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Dawn";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override int Level => 40;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a long sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int InitialTypeSpecificValue => 3;
    public override int Rarity => 120;
    public override bool Regen => true;
    public override bool ResBlind => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool SustCha => true;
    public override int ToA => 0;
    public override int ToD => 20;
    public override int ToH => 20;
    public override bool Vorpal => true;
    public override int Weight => 130;
}
