import { AfterViewChecked, Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { ChatMessage } from './chat-message';
import { NgFor, NgIf } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { ChangeDetectorRef } from '@angular/core';
import { HubService } from '../hub-service/hub.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
  standalone: true,
  imports: [
    NgFor,
    NgIf,
    MatIconModule,
    MatCardModule
  ]
})
export class ChatComponent implements OnInit, OnDestroy, AfterViewChecked {
  @ViewChild('scrollDiv', { static: true }) private scrollDivRef: ElementRef | undefined;
  public history: ChatMessage[] | undefined;
  public isAuthenticated: boolean = false;
  public isAdministrator = false;
  public connectionId: string | null = null;
  private scrollToBottomOfChatAfterViewChecked = false;
  private _initSubscriptions = new Subscription();

  constructor(
    private _snackBar: MatSnackBar,
    private _changeDetectorRef: ChangeDetectorRef,
    private _hubService: HubService
  ) {
  }

  public formatDate(dateString: string | undefined) {
    if (dateString === undefined) {
      return '-';
    }

    const dateNumber: number = Date.parse(dateString);
    const date: Date = new Date(dateNumber);
    const now: Date = new Date();

    // Check to see if the message was sent today.
    if (date.getDate() === now.getDate() && date.getMonth() === now.getMonth() && date.getFullYear() === now.getFullYear()) {
      // Do not show the date.
      return date.toLocaleTimeString([], { hour: 'numeric', minute: 'numeric' });
    } else {
      // Show the date and the time.
      return date.toLocaleDateString();
    }
  }

  public deleteMessage(message: ChatMessage) {
    if (message !== undefined && message.id !== undefined) {
      this._hubService.deleteMessage(message.id).catch(() => {
        this.showMessage('Unable to delete message.');
      });
    }
  }

  public input(event: Event) {
    const inputElement: HTMLTextAreaElement = event.currentTarget as HTMLTextAreaElement;
    const text: string = inputElement.value;
    if (text.endsWith('\n')) {
      const strippedText = text.slice(0, -1);
      if (strippedText.length > 0) {
        this._hubService.sendMessage(strippedText).catch(() => {
          this.showMessage('Unable to send message.');
        });
      }
      inputElement.value = '';
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

  private updateHistory(history: ChatMessage[]) {
    this.showMessage('Chat updated.');
    this.history = history;
    this.scrollToBottomOfChatAfterViewChecked = true;
    this._changeDetectorRef.detectChanges();
  }

  private appendHistory(message: ChatMessage) {
    this.showMessage('Chat message received.');
    this.history?.push(message);
    this.scrollToBottomOfChatAfterViewChecked = true;
    this._changeDetectorRef.detectChanges();
  }

  private showMessage(message: string) {
    console.log(message);
    this._snackBar.open(message, '', {
      duration: 5000
    });
    this._changeDetectorRef.detectChanges();
  }

  ngOnInit(): void {
    // Subscribe to hub events exposed by HubService
    const refreshedSub = this._hubService.onChatRefreshed.subscribe((history: ChatMessage[]) => {
      this.updateHistory(history);
    });
    this._initSubscriptions.add(refreshedSub);

    const updatedSub = this._hubService.onChatUpdated.subscribe((message: ChatMessage) => {
      this.appendHistory(message);
    });
    this._initSubscriptions.add(updatedSub);

    const failedSub = this._hubService.onMessageFailed.subscribe(() => {
      this.showMessage('Unable to send message.');
      this._changeDetectorRef.detectChanges();
    });
    this._initSubscriptions.add(failedSub);

    const connIdSub = this._hubService.connectionId$.subscribe((id: string | null) => {
      this.connectionId = id;
      this._changeDetectorRef.detectChanges();
    });
    this._initSubscriptions.add(connIdSub);

    const authSub = this._hubService.isAuthenticated$.subscribe((v: boolean) => {
      this.isAuthenticated = v;
      this._changeDetectorRef.detectChanges();
    });
    this._initSubscriptions.add(authSub);

    const adminSub = this._hubService.isAdministrator$.subscribe((v: boolean) => {
      this.isAdministrator = v;
      this._changeDetectorRef.detectChanges();
    });
    this._initSubscriptions.add(adminSub);

    const statusSub = this._hubService.status$.subscribe((m: string) => {
      this.showMessage(m);
    });
    this._initSubscriptions.add(statusSub);
  }

  ngOnDestroy() {
    this._initSubscriptions.unsubscribe();
  }
}
