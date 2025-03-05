// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Expressions;

[Serializable]
internal class DifficultyIdentifierExpression : IdentifierExpression
{
    public readonly Game Game;
    public DifficultyIdentifierExpression(Game game, string matchedIdentifier) : base(matchedIdentifier)
    {
        Game = game;
    }
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression) };
    public override Expression Compute()
    {
        return new IntegerExpression(Game.Difficulty);
    }
}