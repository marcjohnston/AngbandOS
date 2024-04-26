// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class PsychometryTalent : Talent
{
    private PsychometryTalent(Game game) : base(game) { }
    public override string Name => "Psychometry";
    public override int Level => 15;
    public override int ManaCost => 12;
    public override int BaseFailure => 60;

    public override void Use()
    {
        if (Game.ExperienceLevel.IntValue < 40)
        {
            Psychometry();
        }
        else
        {
            Game.RunScript(nameof(IdentifyItemScript));
        }
    }

    protected override string Comment()
    {
        return string.Empty;
    }

    private void Psychometry()
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
        string oName = oPtr.Description(false, 0);
        if (string.IsNullOrEmpty(feel))
        {
            Game.MsgPrint($"You do not perceive anything unusual about the {oName}.");
            return;
        }
        string s = oPtr.Count == 1 ? "is" : "are";
        Game.MsgPrint($"You feel that the {oName} {s} {feel}...");
        oPtr.IdentSense = true;
        if (string.IsNullOrEmpty(oPtr.Inscription))
        {
            oPtr.Inscription = feel;
        }
        Game.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
    }
}