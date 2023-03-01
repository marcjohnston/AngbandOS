namespace AngbandOS.Core.HelpGroups
{
    [Serializable]
    internal class WizardMovementHelpGroup : HelpGroup
    {
        private WizardMovementHelpGroup(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override string Title => "Movement";
        public override int SortIndex => 4;
    }
}
