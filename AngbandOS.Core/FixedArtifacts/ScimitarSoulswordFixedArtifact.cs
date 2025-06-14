// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ScimitarSoulswordFixedArtifact : FixedArtifact
{
    private ScimitarSoulswordFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(ScimitarWeaponItemFactory);


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
    public override string Name => "The Scimitar 'Soulsword'";
    public override int Ac => 0;
    public override bool Blessed => true;
    public override bool Blows => true;
    public override int Cost => 111111;
    public override int TreasureRating => 20;
    public override int Dd => 2;
    public override int Ds => 5;
    public override string FriendlyName => "'Soulsword'";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 20;
    protected override string? BonusIntelligenceRollExpression => "2";
    protected override string? BonusWisdomRollExpression => "2";
    public override int Rarity => 8;
    public override bool ResChaos => true;
    public override bool ResDisen => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDemon => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override int ToA => 0;
    public override int ToD => 11;
    public override int ToH => 9;
    public override int Weight => 130;
    public override bool Wis => true;
}
