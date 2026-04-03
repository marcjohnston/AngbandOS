// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.RaceGenders;

[Serializable]
internal sealed class RaceGender : IGetKey, IToJson
{
    private Game Game { get; }
    public RaceGender(Game game, RaceGenderGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        RaceBindingKey = gameConfiguration.RaceBindingKey;
        GenderBindingKey = gameConfiguration.GenderBindingKey;
        PhysicalAttributesWeightedRandomBindings = gameConfiguration.PhysicalAttributesWeightedRandomBindings;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        RaceGenderGameConfiguration definition = new RaceGenderGameConfiguration()
        {
            RaceBindingKey = RaceBindingKey,
            GenderBindingKey = GenderBindingKey,
            PhysicalAttributesWeightedRandomBindings = PhysicalAttributesWeightedRandomBindings,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public string Key { get; }
    public string GetKey => $"{RaceBindingKey}-{GenderBindingKey}";
    public static string GetCompositeKey(Race race, Gender gender) => GameConfiguration.GetCompositeKey(race.GetKey, gender.GetKey);
    public void Bind(RestoreGameState? restoreGameState)
    {
        Race = Game.SingletonRepository.Get<Race>(RaceBindingKey);
        Gender = Game.SingletonRepository.Get<Gender>(GenderBindingKey);
        (PhysicalAttributeSet PhysicalAttributeSet, int Weight)[] physicalAttributesWeightedRandoms = PhysicalAttributesWeightedRandomBindings.Select(_physicalAttributesWeightedRandomBinding => (Game.SingletonRepository.Get<PhysicalAttributeSet>(_physicalAttributesWeightedRandomBinding.PhysicalAttributesBindingKey), _physicalAttributesWeightedRandomBinding.Weight)).ToArray();
        PhysicalAttributesWeightedRandom = new WeightedRandom<PhysicalAttributeSet>(Game, physicalAttributesWeightedRandoms);
    }

    public Race Race { get; private set; }
    public Gender Gender { get; private set; }
    public WeightedRandom<PhysicalAttributeSet> PhysicalAttributesWeightedRandom { get; private set; }
    private string RaceBindingKey { get; }
    private string GenderBindingKey { get; }
    private (string PhysicalAttributesBindingKey, int Weight)[] PhysicalAttributesWeightedRandomBindings { get; }
}

