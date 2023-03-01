namespace AngbandOS.Core.HelpGroups
{
    internal class WizardObjectCommandsHelpGroup : HelpGroup
    {
        private WizardObjectCommandsHelpGroup(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override string Title => "Object Commands";

        public override int SortIndex => 2;
    }
}
