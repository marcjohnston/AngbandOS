// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class RaceAbility : IGetKey
{
    protected readonly Game Game;
    public RaceAbility(Game game)
    {
        Game = game;
    }
    public virtual int Bonus { get; } = 0;
    public Race Race { get; private set; }
    public Ability Ability { get; private set; }
    public virtual string RaceBindingKey { get; }
    public virtual string AbilityBindingKey { get; }
    public string GetKey => $"{RaceBindingKey}-{AbilityBindingKey}";

    public static string GetCompositeKey(Race race, Ability ability) => $"{race.Key}-{ability.Key}";
    public void Bind()
    {
        Race = Game.SingletonRepository.Get<Race>(RaceBindingKey);
        Ability = Game.SingletonRepository.Get<Ability>(AbilityBindingKey);
    }

    public string ToJson()
    {
        return "";
    }
}
