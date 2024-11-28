// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordOfEverflameFixedArtifact : FixedArtifact
{
    private LongSwordOfEverflameFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(LongSwordWeaponItemFactory);

    // Everflame shoots a fire ball
    protected override string? ActivationName => nameof(BallOfFire72r2Every400Activation);

    public override void ApplyResistances(Item item)
    {
        if (Game.DieRoll(2) == 1)
        {
            item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
        }
        else
        {
            item.RandomPower = Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(AbilityItemEnhancementWeightedRandom)).Choose();
        }
    }

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Long Sword of Everflame";
    public override int Ac => 0;
    public override bool BrandFire => true;
    public override int Cost => 80000;
    public override int TreasureRating => 20;
    public override int Dd => 2;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Everflame";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a long sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    protected override string? BonusStrengthRollExpression => "4";
    public override int Rarity => 40;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
    public override bool SustDex => true;
    public override int ToA => 5;
    public override int ToD => 15;
    public override int ToH => 10;
    public override int Weight => 130;
}
