// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Animations;

[Serializable]
internal class WhiteExpandAnimation : Animation
{
    private WhiteExpandAnimation(Game game) : base(game) { } // This object is a singleton.
    public override char Character => '*';
    public override string Name => "WhiteExpand";
    public override string Sequence => @"·oO";
    public override ColorEnum Color => ColorEnum.White;
    public override ColorEnum AlternateColor => ColorEnum.White;
}
