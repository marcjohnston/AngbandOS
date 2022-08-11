import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import * as SignalR from "@microsoft/signalr";

export class PostNewGame {
  public username: string = "";
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public readonly connection = new SignalR.HubConnectionBuilder().withUrl("/hub", { transport: SignalR.HttpTransportType.WebSockets }).build();
  public gameGuid: string | null = null;
  public connectionId: string | null = null;

  constructor(
    private _httpClient: HttpClient
  ) {

  }

  ngOnInit(): void {
    const postNewGame: PostNewGame = {
      username: "marc"
    };
    this._httpClient.post<string>(`api/games`, postNewGame).toPromise().then((guid: string | undefined) => {
      if (guid !== undefined) {
        this.gameGuid = guid;
      }
    }, (error: HttpErrorResponse) => {
      this.gameGuid = "post failed";
    });
    this.connection.start().then(() => {
      this.connectionId = `Success: ${this.connection.connectionId}`;
    }, (error: any) => {
      this.connectionId = `error ${error}`;
    }).catch((error: any) => {
      this.connectionId = `threw ${error}`;
    });
  //  this._httpClient.get<string>(`api/games`).toPromise().then((guid: string | undefined) => {
  //    this.gameGuid = "get worked";
  //  }, (error: HttpErrorResponse) => {
  //    this.gameGuid = "get failed";
  //  });
  }
}

