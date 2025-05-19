// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.RaceGenders;

[Serializable]
internal abstract class RaceGender : IGetKey
{
    protected readonly Game Game;
    protected RaceGender(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public string GetKey => $"{RaceBindingKey}-{GenderBindingKey}";

    public void Bind()
    {
        Race = Game.SingletonRepository.Get<Race>(RaceBindingKey);
        Gender = Game.SingletonRepository.Get<Gender>(GenderBindingKey);
        (PhysicalAttributeSet PhysicalAttributeSet, int Weight)[] physicalAttributesWeightedRandoms = PhysicalAttributesWeightedRandomBindings.Select(_physicalAttributesWeightedRandomBinding => (Game.SingletonRepository.Get<PhysicalAttributeSet>(_physicalAttributesWeightedRandomBinding.PhysicalAttributesBindingKey), _physicalAttributesWeightedRandomBinding.Weight)).ToArray();
        PhysicalAttributesWeightedRandom = new WeightedRandom<PhysicalAttributeSet>(Game, physicalAttributesWeightedRandoms);
    }

    public static string GetCompositeKey(Race t1, Gender t2) => $"{t1.GetKey}-{t2.GetKey}";

    public Race Race { get; private set; }
    public Gender Gender { get; private set; }
    protected abstract string RaceBindingKey { get; }
    protected abstract string GenderBindingKey { get; }
    public WeightedRandom<PhysicalAttributeSet> PhysicalAttributesWeightedRandom { get; private set; }
    protected abstract (string PhysicalAttributesBindingKey, int Weight)[] PhysicalAttributesWeightedRandomBindings { get; }
}
