// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal abstract class ActiveMutationScript : IGetKey, IGameSerialize, IScript
{
    protected Game Game { get; }
    protected ActiveMutationScript(Game game)
    {
        Game = game;
    }
    public virtual string Key => GetType().Name;
    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState)
    {
        DamageExpression = Game.ParseNullableNumericExpression(DamageExpressionText);
    }
    public abstract string Name { get; }
    protected virtual string? DamageExpressionText => null;
    public Expression? DamageExpression { get; private set; }
    public virtual GameStateBag? Serialize(SaveGameState saveGameState) => null;

    public abstract void ExecuteScript();
}