// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.RaceGenders;

[Serializable]
internal class HalfTitanOtherRaceGender : RaceGender
{
    private HalfTitanOtherRaceGender(Game game) : base(game) { }
    protected override string RaceBindingKey => nameof(HalfTitanRace);
    protected override string GenderBindingKey => nameof(OtherGender);
    protected override (string PhysicalAttributesBindingKey, int Weight)[] PhysicalAttributesWeightedRandomBindings => new (string PhysicalAttributesBindingKey, int Weight)[]
    {
        (nameof(HalfTitanMalePhysicalAttributeSet), 1),
        (nameof(HalfTitanFemalePhysicalAttributeSet), 1)
    };
}
