﻿namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class ApplyDisenchantWizardCommand : WizardCommand
    {
        private ApplyDisenchantWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'D';

        public override void Execute()
        {
            SaveGame.ApplyDisenchant();
        }
    }
}