// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfElementalPowerFireFixedArtifact : FixedArtifact
{
    private RingOfElementalPowerFireFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(NaryaRingItemFactory);

    // Ring of Elemental Fire casts a fireball
    protected override string? ActivationName => nameof(FireBall120r3Every225p1d225Activation);

    public override string Name => "The Ring of Elemental Power (Fire)";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 100000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Fire)";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 70;
    public override int InitialTypeSpecificValue => 1;
    public override int Rarity => 30;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustDex => true;
    public override bool SustStr => true;
    public override int ToA => 0;
    public override int ToD => 10;
    public override int ToH => 10;
    public override int Weight => 2;
    public override bool Wis => true;
}
