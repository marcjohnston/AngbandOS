// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class RacialPower : IGetKey, IScript
{
    protected readonly Game Game;
    protected RacialPower(Game game)
    {
        Game = game;
    }
    public static string GetCompositeKey(Race race, BaseCharacterClass? characterClass) => Game.GetCompositeKey(race.GetKey, characterClass?.GetKey, nameof(RacialPower));
    public IScript Script { get; private set; }
    protected abstract string ScriptBindingKey { get; }
    public Race Race { get; private set; }
    protected abstract string RaceBindingKey { get; }
    public BaseCharacterClass? CharacterClass { get; private set; }
    protected virtual string? CharacterClassBindingKey { get; } = null;

    public string GetKey => Game.GetCompositeKey(RaceBindingKey, CharacterClassBindingKey, nameof(RacialPower));

    public void Bind()
    {
        Script = Game.SingletonRepository.Get<IScript>(ScriptBindingKey);
        Race = Game.SingletonRepository.Get<Race>(RaceBindingKey);
        CharacterClass = Game.SingletonRepository.GetNullable<BaseCharacterClass>(CharacterClassBindingKey);
    }

    public string ToJson()
    {
        return "";
    }

    public void ExecuteScript()
    {
        Script.ExecuteScript();
    }
}
