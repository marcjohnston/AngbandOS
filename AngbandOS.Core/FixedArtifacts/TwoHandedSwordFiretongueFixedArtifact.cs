// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedSwordFiretongueFixedArtifact : FixedArtifact
{
    private TwoHandedSwordFiretongueFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(TwoHandedSwordWeaponItemFactory);


    public override void ApplyResistances(Item item)
    {
        if (Game.DieRoll(2) == 1)
        {
            item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
        }
        else
        {
            item.RandomPower = Game.SingletonRepository.ToWeightedRandom<Power>(_power => _power.IsAbility == true).Choose();
        }
    }
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Two-Handed Sword 'Firetongue'";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int Cost => 205000;
    public override int Dd => 4;
    public override int Ds => 6;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Firetongue'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool KillDragon => true;
    public override int Level => 30;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a two-handed sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int InitialTypeSpecificValue => 4;
    public override int Rarity => 180;
    public override bool ResChaos => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 21;
    public override int ToH => 19;
    public override bool Vorpal => true;
    public override int Weight => 250;
}
