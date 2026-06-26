// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class PsychometryTalentScript : UniversalScript, IGetKey
{
    private PsychometryTalentScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState) { }
    public override void ExecuteScript()
    {
        if (Game.ExperienceLevel.IntValue < 40)
        {
            if (!Game.SelectItem(out Item? oPtr, "Meditate on which item? ", true, true, true, null))
            {
                Game.MsgPrint("You have nothing appropriate.");
                return;
            }
            if (oPtr == null)
            {
                return;
            }
            if (oPtr.IsKnown() || oPtr.IdentSense)
            {
                Game.MsgPrint("You cannot find out anything more about that.");
                return;
            }
            string feel = oPtr.GetDetailedFeeling();
            string oName = oPtr.GetDescription(false);
            if (string.IsNullOrEmpty(feel))
            {
                Game.MsgPrint($"You do not perceive anything unusual about the {oName}.");
                return;
            }
            string s = oPtr.StackCount == 1 ? "is" : "are";
            Game.MsgPrint($"You feel that the {oName} {s} {feel}...");
            oPtr.IdentSense = true;
            if (string.IsNullOrEmpty(oPtr.Inscription))
            {
                oPtr.Inscription = feel;
            }
            Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        }
        else
        {
            Game.RunScript(nameof(IdentifyItemScript));
        }
    }
}
