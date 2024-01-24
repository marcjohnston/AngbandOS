// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedWhiteFlashAnimation : Animation
{
    private RedWhiteFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    protected override string ColorName => nameof(ColourEnum.BrightWhite);
    public override string Name => "RedWhiteFlash";
    protected override string AlternateColorName => nameof(ColourEnum.BrightRed);
    public override string Sequence => @"********";
}
