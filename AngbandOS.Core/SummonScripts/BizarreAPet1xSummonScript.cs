// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.SummonScripts;

[Serializable]
internal class BizarreAPet1xSummonScript : SummonScript
{
    private BizarreAPet1xSummonScript(Game game) : base(game) { } // This object is a singleton

    protected override string MonsterFilterBindingKey => nameof(Bizarre1MonsterFilter);
    public override bool Pet => true;
    public override bool Group => false;
    protected override string LevelRollExpression => "X";
    public override string? PreMessage => "You concentrate on the Fool card...";
    public override string? FailureMessage => "No-one ever turns up.";
}
