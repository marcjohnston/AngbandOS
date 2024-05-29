// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedSwordDragonslayerFixedArtifact : FixedArtifact
{
    private TwoHandedSwordDragonslayerFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(TwoHandedSwordWeaponItemFactory);


    public override void ApplyResistances(Item item)
    {
        if (Game.DieRoll(2) == 1)
        {
            item.ApplyRandomResistance(Game.DieRoll(22) + 16);
        }
        else
        {
            item.RandomPower = Game.SingletonRepository.ToWeightedRandom<Power>(_power => _power.IsAbility == true).Choose();
        }
    }
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Two-Handed Sword 'Dragonslayer'";
    public override int Ac => 0;
    public override int Cost => 100000;
    public override int Dd => 3;
    public override int Ds => 6;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Dragonslayer'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 30;
    public override int InitialTypeSpecificValue => 2;
    public override int Rarity => 30;
    public override bool Regen => true;
    public override bool ShowMods => true;
    public override bool SlayTroll => true;
    public override bool SlowDigest => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 17;
    public override int ToH => 13;
    public override int Weight => 200;
}
