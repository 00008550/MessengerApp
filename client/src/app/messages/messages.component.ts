import { Component, OnInit } from '@angular/core';
import { Message } from '../_models/message';
import { Pagination } from '../_models/pagination';
import { MessageService } from '../_services/message.service';

type GUID = string & {isGuid:true};
function guid(guid:string):GUID {
    return guid as GUID;
}
@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {
  messages: Message[] = [];
  pagination: Pagination;
  container = 'Unread';
  pageNumber = 1;
  pageSize = 5;
  loading = false;


  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages(){
    this.loading = true;
    this.messageService.getMessages(this.pageNumber, this.pageSize, this.container).subscribe(response=> {
      this.messages = response.result;
      this.pagination = response.pagination;
      this.loading = false;
    })
  }

  deleteMessage(id: GUID){
    this.messageService.deleteMessage(id).subscribe(()=>{
      this.messages.splice(this.messages.findIndex(m=> m.id ===id), 1);
    })
  }

  pageChanged(event: any){
    if (this.pageNumber !== event.page){
      this.pageNumber = event.page;
      this.loadMessages();
    }
    
  }

}
