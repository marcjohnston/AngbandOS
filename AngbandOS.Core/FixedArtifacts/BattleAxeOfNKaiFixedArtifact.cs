// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BattleAxeOfNKaiFixedArtifact : FixedArtifact
{
    private BattleAxeOfNKaiFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(BattleAxePolearmWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Battle Axe of N'Kai";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 90000;
    public override int TreasureRating => 20;
    public override int Dd => 3;
    public override int Ds => 8;
    public override bool Feather => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of N'Kai";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    protected override string? BonusConstitutionRollExpression => "3";
    protected override string? BonusStealthRollExpression => "3";
    protected override string? BonusStrengthRollExpression => "3";
    public override int Rarity => 15;
    public override bool Regen => true;
    public override bool ResAcid => true;
    public override bool ResBlind => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Stealth => true;
    public override bool Str => true;
    public override int ToA => 5;
    public override int ToD => 11;
    public override int ToH => 8;
    public override int Weight => 170;
}
