// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Represents a <see cref="WeightedRandom"/> object that implements the IGetKey interface for configuration objects.
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
internal abstract class GenericWeightedRandom<T> : WeightedRandom<T>, IGetKey where T : class
{
    protected GenericWeightedRandom(Game game) : base(game) { }
    protected abstract (string name, int weight)[] NameAndWeightBindingTuples { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        foreach ((string name, int weight) in NameAndWeightBindingTuples)
        {
            Add(weight, Game.SingletonRepository.Get<T>(name));
        }
    }

    public string ToJson()
    {
        return "";
    }
}
