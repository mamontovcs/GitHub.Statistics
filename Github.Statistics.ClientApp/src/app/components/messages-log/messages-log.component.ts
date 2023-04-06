import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import { MessageLogService } from 'src/app/services/message-log.service';

@Component({
  selector: 'app-messages-log',
  templateUrl: './messages-log.component.html',
  styleUrls: ['./messages-log.component.css'],
  providers: [MessageService]
})
export class MessagesLogComponent {

  constructor(private _messageLogService: MessageLogService, private _messageService: MessageService) { }

  ngOnInit() {
    this._messageLogService.message.subscribe(message => this.addMessage(message))
  }

  public addMessage(message: string) {
    this._messageService.add({ severity: 'success', summary: message, detail: 'Via MessageService' })
  }
}
