// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectMagicalObjectsScript : Script, IScript, ICastSpellScript
{
    private DetectMagicalObjectsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool detect = false;
        for (int y = 1; y < Game.CurHgt - 1; y++)
        {
            for (int x = 1; x < Game.CurWid - 1; x++)
            {
                GridTile cPtr = Game.Map.Grid[y][x];
                foreach (Item oPtr in cPtr.Items)
                {
                    if (!Game.PanelContains(y, x))
                    {
                        continue;
                    }
                    if (oPtr.IsArtifact || oPtr.IsRare || oPtr.IsMagical || oPtr.EffectivePropertySet.BonusArmorClass > 0 || oPtr.EffectivePropertySet.BonusHit + oPtr.EffectivePropertySet.BonusDamage > 0)
                    {
                        oPtr.WasNoticed = true;
                        Game.ConsoleView.RefreshMapLocation(y, x);
                        detect = true;
                    }
                }
            }
        }
        if (detect)
        {
            Game.MsgPrint("You sense the presence of magic objects!");
        }
    }
    public string LearnedDetails => "";
}
