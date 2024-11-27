// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TridentOfTheGnorriFixedArtifact : FixedArtifact
{
    private TridentOfTheGnorriFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(TridentPolearmWeaponItemFactory);
    protected override string? ActivationName => nameof(TeleportAwayEvery150Activation);
    public override void ApplyResistances(Item item)
    {
        item.RandomPower = Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(AbilityItemEnhancementWeightedRandom)).Choose();
    }
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "The Trident of the Gnorri";
    public override int Ac => 0;
    public override bool Blessed => true;
    public override int Cost => 120000;
    public override int TreasureRating => 20;
    public override int Dd => 4;
    public override bool Dex => true;
    public override int Ds => 8;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Gnorri";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override int Level => 30;
    protected override string? BonusDexterityRollExpression => "4";
    public override int Rarity => 90;
    public override bool Regen => true;
    public override bool ResNether => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDragon => true;
    public override bool SlowDigest => true;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 15;
    public override int Weight => 70;
}
