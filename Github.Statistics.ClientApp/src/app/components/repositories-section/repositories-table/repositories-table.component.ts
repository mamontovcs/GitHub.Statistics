import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { RepositoryInfo } from 'src/app/models/RepositoryInfo';
import { RepositoryInfoService } from 'src/app/services/repository-info.service';
import { MessagesLogComponent } from '../../messages-log/messages-log.component';
import { MessageLogService } from 'src/app/services/message-log.service';

@Component({
  selector: 'app-repositories-table',
  templateUrl: './repositories-table.component.html',
  styleUrls: ['./repositories-table.component.css'],
  providers: [MessageService]
})
export class RepositoriesTableComponent {

  displayedColumns: string[] = ['Id', 'Name'];
  data: MatTableDataSource<RepositoryInfo>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private router: Router, private _repositoryInfoService: RepositoryInfoService,
    private _messageLogService: MessageLogService) {
  }

  message: string;
  ngOnInit() {
    this._repositoryInfoService.getRepositories().subscribe(response => {
      this.data = new MatTableDataSource(response);
      this.data.paginator = this.paginator;
      this.data.sort = this.sort;
      this._messageLogService.addMessage("Data is loaded successfully1");
      setTimeout(() => {
        this._messageLogService.addMessage("Data is loaded successfully2");
      }, 1000);
    });
  }


  applyFilter(event: Event) {
    let filterValue = (event.target as HTMLInputElement).value;
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.data.filter = filterValue;
  }

  onRepositorySelected(repositoryInfo: RepositoryInfo) {
    this.router.navigateByUrl('/repository-page/' + repositoryInfo.id)
  }
}
