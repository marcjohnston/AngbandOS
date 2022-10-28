import { AfterViewChecked, Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { ChatMessage } from './chat-message';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit, OnDestroy, AfterViewChecked {
  @ViewChild('scrollDiv', { static: true }) private scrollDivRef: ElementRef | undefined;
  private chatConnection: SignalR.HubConnection | undefined;
  private serviceConnection: SignalR.HubConnection | undefined;
  public history: ChatMessage[] | undefined;
  private subscriptions = new Subscription();
  public isAuthenticated: boolean = false;
  public isAdministrator = false;
  private scrollToBottomOfChatAfterViewChecked = false;
  public connectionId: string | null = null;

  constructor(
    private _authenticationService: AuthenticationService,
    private _snackBar: MatSnackBar,
    private _ngZone: NgZone
  ) {
 }

  public formatDate(dateString: string | undefined) {
    if (dateString === undefined) {
      return "-";
    }

    const dateNumber: number = Date.parse(dateString);
    const date: Date = new Date(dateNumber);
    const now: Date = new Date();

    // Check to see if the message was sent today.
    if (date.getDay() === now.getDay() && date.getMonth() === now.getMonth() && date.getFullYear() === now.getFullYear()) {
      // Do not show the date.
      return date.toLocaleTimeString([], { hour: 'numeric', minute: 'numeric' });
    } else {
      // Show the date and the time.
      return date.toLocaleDateString();
   ;
    }
  }

  public input(event: Event) {
    if (this.chatConnection !== undefined) {
      const inputElement: HTMLTextAreaElement = event.currentTarget as HTMLTextAreaElement;
      const text: string = inputElement.value;
      if (text.endsWith("\n")) {
        const strippedText = text.slice(0, -1);
        if (strippedText.length > 0) {
          this.chatConnection.send("SendMessage", null, strippedText);
        }
        inputElement.value = "";
      }
    }
  }

  private scrollToBottomOfChat() {
    const scrollDiv: HTMLDivElement = this.scrollDivRef?.nativeElement as HTMLDivElement;
    scrollDiv.scrollTop = scrollDiv.scrollHeight;
  }

  ngAfterViewChecked() {
    if (this.scrollToBottomOfChatAfterViewChecked) {
      this.scrollToBottomOfChatAfterViewChecked = false;
      this.scrollToBottomOfChat();
    }
  }

  private connectServiceHub() {
    this.serviceConnection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/service-hub").build();
    this.serviceConnection.start().then(() => {
      this.connectionId = `Service: ${this.serviceConnection?.connectionId!}`;
      if (this.serviceConnection !== undefined) {
        this.serviceConnection.on("ChatRefreshed", (_history: ChatMessage[]) => {
          this._ngZone.run(() => {
            this.history = _history;
            this.scrollToBottomOfChatAfterViewChecked = true;
          })
        });
        this.serviceConnection.on("ChatUpdated", (_message: ChatMessage) => {
          this._ngZone.run(() => {
            this.history?.push(_message);
            this.scrollToBottomOfChatAfterViewChecked = true;
          })
        });
        this.serviceConnection.send("RefreshChat", null);
      }
    });
  }

  private connectChatHub(accessToken: string) {
    this.chatConnection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/chat-hub", {
      accessTokenFactory: () => accessToken
    }).build();
    this.chatConnection.start().then(() => {
      this.connectionId = `Chat: ${this.chatConnection?.connectionId!}`;
      if (this.chatConnection !== undefined) {
        this.chatConnection.on("ChatRefreshed", (_history: ChatMessage[]) => {
          this._ngZone.run(() => {
            this.history = _history;
            this.scrollToBottomOfChatAfterViewChecked = true;
          })
        });
        this.chatConnection.on("ChatUpdated", (_message: ChatMessage) => {
          this._ngZone.run(() => {
            this.history?.push(_message);
            this.scrollToBottomOfChatAfterViewChecked = true;
          })
        });
        this.chatConnection.on("MessageFailed", () => {
          this._ngZone.run(() => {
            this._snackBar.open("Unable to send message.", "", {
              duration: 5000
            });
          })
        });
        this.chatConnection.send("RefreshChat", null);
      }
    });
  }

  private handleAuthenticationChange() {
    this.disconnectChatHub();
    this.disconnectServiceHub();

    // Check to see if we are authenticated.
    if (this._authenticationService.currentUser.value == null || this._authenticationService.currentUser.value?.jwt === undefined) {
      // Connect to the anonymous service-hub.
      this.isAuthenticated = false;
      this.connectServiceHub();
    } else {
      this.isAuthenticated = true;
      this.isAdministrator = this._authenticationService.currentUser.value?.isAdmin!;
      const accessToken = this._authenticationService.currentUser.value.jwt;
      this.connectChatHub(accessToken);
    }
  }

  ngOnInit(): void {
    this.subscriptions.add(this._authenticationService.currentUser.subscribe((_user: UserDetails | null) => {
      this.handleAuthenticationChange();
    }));
  }

  private disconnectServiceHub() {
    if (this.serviceConnection !== undefined) {
      this.serviceConnection.off("ChatUpdated");
      this.serviceConnection.off("ChatRefreshed");
      this.serviceConnection.stop();
    }
  }

  private disconnectChatHub() {
    if (this.chatConnection !== undefined) {
      this.chatConnection.off("ChatUpdated");
      this.chatConnection.off("MessageFailed");
      this.chatConnection.off("ChatRefreshed");
      this.chatConnection.stop();
    }
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
    this.disconnectServiceHub();
    this.disconnectChatHub();
  }
}
