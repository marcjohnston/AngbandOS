﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class RerollHitPointsWizardCommand : WizardCommand
{
    private RerollHitPointsWizardCommand(Game game) : base(game) { } // This object is a singleton.

    public override char KeyChar => 'h';

    public override string HelpDescription => "Reroll Hitpoints";

    protected override string? HelpGroupName => nameof(WizardCharacterEditingHelpGroup);

    protected override string? ExecuteScriptName => nameof(RerollHitPointsScript);
}
