// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class StunnedIntWidget : RangedIntWidget
{
    private StunnedIntWidget(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override int X => 0;
    public override int Y => 44;
    public override int Width => 11;
    public override string IntChangeTrackableName => nameof(StunnedTimer);

    public override (int, string, ColorEnum)[] Ranges => new (int, string, ColorEnum)[]
    {
        (101, "Knocked out", ColorEnum.Red),
        (51, "Heavy stun", ColorEnum.Orange),
        (1, "Stun", ColorEnum.Orange)
    };
}
