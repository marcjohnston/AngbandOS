// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DemonServantPetSummonScript : SummonScript
{
    private DemonServantPetSummonScript(Game game) : base(game) { }

    protected override string MonsterFilterBindingKey => nameof(DemonMonsterFilter);

    protected override string LevelRollExpression => "X*3/2";
    public override string[]? FailureMessages => new string[] { "No-one ever turns up." };
    public override string[]? SuccessMessages => new string[] { "The area fills with a stench of sulphur and brimstone.", "'What is thy bidding... Master?'" };
    public override bool Pet => true;
    protected override string GroupBooleanExpression => "X==50";
}
