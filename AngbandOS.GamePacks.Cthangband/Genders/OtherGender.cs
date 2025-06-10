// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OtherGender : GenderGameConfiguration
{
    public override string Title => "Other";
    public override string Winner => "Monarch";

    /// <summary>
    /// Returns false, because the Other gender shouldn't be selected when a random character is chosen.
    /// </summary>
    public override bool CanBeRandomlySelected => false;
}