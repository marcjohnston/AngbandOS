// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

[Serializable]
internal class SkidneyTheSorcererShopkeeper : Shopkeeper
{
    private SkidneyTheSorcererShopkeeper(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Skidney the Sorcerer";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    protected override string? RaceName => nameof(HalfElfRace);
}