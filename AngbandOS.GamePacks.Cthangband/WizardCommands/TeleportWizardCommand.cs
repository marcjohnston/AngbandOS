﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportWizardCommand : WizardCommandGameConfiguration
{
    public override char KeyChar => 't';

    public override string HelpDescription => "Teleport";

    public override string? HelpGroupName => nameof(WizardMovementHelpGroup);

    public override string? ExecuteScriptName => nameof(TeleportSelf100TeleportSelfScript);
}
