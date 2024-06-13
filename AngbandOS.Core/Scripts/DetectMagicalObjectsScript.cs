// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectMagicalObjectsScript : Script, IScript
{
    private DetectMagicalObjectsScript(Game game) : base(game) { }

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
                    ItemTypeEnum tv = oPtr.Factory.CategoryEnum;
                    if (oPtr.IsArtifact != null || oPtr.IsRare() ||
                        tv == ItemTypeEnum.Amulet || tv == ItemTypeEnum.Ring || tv == ItemTypeEnum.Staff ||
                        tv == ItemTypeEnum.Wand || tv == ItemTypeEnum.Rod || tv == ItemTypeEnum.Scroll ||
                        tv == ItemTypeEnum.Potion || tv == ItemTypeEnum.LifeBook || tv == ItemTypeEnum.SorceryBook ||
                        tv == ItemTypeEnum.NatureBook || tv == ItemTypeEnum.ChaosBook || tv == ItemTypeEnum.DeathBook ||
                        tv == ItemTypeEnum.CorporealBook || tv == ItemTypeEnum.TarotBook || tv == ItemTypeEnum.FolkBook ||
                        oPtr.BonusArmorClass > 0 || oPtr.BonusHit + oPtr.BonusDamage > 0)
                    {
                        oPtr.WasNoticed = true;
                        Game.MainForm.RefreshMapLocation(y, x);
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
}
