import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageLogService {

  constructor() { }

  private addMessageSubject = new BehaviorSubject<string>("");
  message = this.addMessageSubject.asObservable();

  addMessage(message: string) {
    this.addMessageSubject.next(message);
  }
}
