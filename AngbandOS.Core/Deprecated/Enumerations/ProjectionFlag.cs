﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Flags]
internal enum ProjectionFlag
{
    ProjectNone = 0x00,
    ProjectJump = 0x01,
    ProjectBeam = 0x02,
    ProjectThru = 0x04,
    ProjectStop = 0x08,
    ProjectGrid = 0x10,
    ProjectItem = 0x20,
    ProjectKill = 0x40,
    ProjectHide = 0x80,
}