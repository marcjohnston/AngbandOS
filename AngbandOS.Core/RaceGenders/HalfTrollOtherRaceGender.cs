// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.RaceGenders;

[Serializable]
internal class HalfTrollOtherRaceGender : RaceGender
{
    private HalfTrollOtherRaceGender(Game game) : base(game) { }
    protected override string RaceBindingKey => nameof(HalfTrollRace);
    protected override string GenderBindingKey => nameof(OtherGender);
    protected override (string PhysicalAttributesBindingKey, int Weight)[] PhysicalAttributesWeightedRandomBindings => new (string PhysicalAttributesBindingKey, int Weight)[]
    {
        (nameof(HalfTrollMalePhysicalAttributeSet), 1),
        (nameof(HalfTrollFemalePhysicalAttributeSet), 1)
    };
}
