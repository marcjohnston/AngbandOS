﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class WizardCommandsRepository : DictionaryRepository<string, WizardCommand>
{
    public WizardCommandsRepository(SaveGame saveGame) : base(saveGame) { }

    public override void Load()
    {
        base.Load();

        foreach (WizardCommand command in this)
        {
            if (this.Count(_wizardCommand => _wizardCommand.KeyChar == command.KeyChar) > 1)
            {
                throw new Exception($"More than one wizard command accepts the key {command.KeyChar}.");
            }
        }
    }
}