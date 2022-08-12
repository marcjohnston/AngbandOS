import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import * as SignalR from "@microsoft/signalr";

export class PostNewGame {
  public username: string = "";
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public readonly connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/hub").build();
  public connectionId: string | null = null;
  public gameGuid: string | null = null;

  constructor(
    private _httpClient: HttpClient
  ) {
    const postNewGame: PostNewGame = {
      username: "marc"
    };
    this._httpClient.post<string>(`/apiv1/games`, postNewGame).toPromise().then((guid: string | undefined) => {
      if (guid !== undefined) {
        this.gameGuid = guid;
      }
    }, (error: HttpErrorResponse) => {
      this.gameGuid = "post failed";
    });
    this.connection.start().then(() => {
      this.connectionId = this.connection.connectionId;
    });
  }
}
