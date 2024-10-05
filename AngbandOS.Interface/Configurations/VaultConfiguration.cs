// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.Interface;

[Serializable]
public class VaultConfiguration : IConfiguration
{
    public virtual string Key { get; set; }
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;
    public virtual string Name { get; set; }
    public virtual int Category { get; set; }
    public virtual int Height { get; set; }
    public virtual int Rating { get; set; }
    public virtual string Text { get; set; }
    public virtual int Width { get; set; }

    public bool IsValid()
    {
        if (Key == null || Color == null || Name == null || Category == null || Height == null || Rating == null || Text == null || Width == null)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return Key;
    }
}
