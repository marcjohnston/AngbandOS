import { Injectable } from '@angular/core';

import { PlayComponent } from '../play/play.component';

@Injectable()
export class CanDeactivatePlay  {

  canDeactivate(target: PlayComponent) {
    if (target.GameInProgress) {
      return window.confirm('If you leave this screen, your game will cancelled and all progress will be lost since the game was last saved.  Do you want to abort the game?');
    } else {
      return true;
    }
  }
}
