﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.SummonScripts;

[Serializable]
internal class AnimalRangerPet1xSummonScript : BaseSummonScript
{
    private AnimalRangerPet1xSummonScript(Game game) : base(game) { } // This object is a singleton

    protected override string MonsterFilterBindingKey => nameof(AnimalRangerMonsterFilter);
    public override bool Group => false;
    public override bool Pet => true;
    protected override string LevelRollExpression => "1d1xX";
    public override string? PreMessage => "You concentrate on the image of an animal...";
    public override string? FailureMessage => "No-one ever turns up.";
}