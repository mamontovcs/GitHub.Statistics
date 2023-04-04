import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { RepositoryInfo } from 'src/app/models/RepositoryInfo';
import { RepositoryInfoService } from 'src/app/services/repository-info.service';

@Component({
  selector: 'app-repositories-table',
  templateUrl: './repositories-table.component.html',
  styleUrls: ['./repositories-table.component.css']
})
export class RepositoriesTableComponent {

  displayedColumns: string[] = ['Id', 'Name'];
  data: MatTableDataSource<RepositoryInfo>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private router: Router, private _repositoryInfoService: RepositoryInfoService) {
  }

  ngOnInit() {
    this._repositoryInfoService.getRepositories().subscribe(response => {
      this.data = new MatTableDataSource(response);
      this.data.paginator = this.paginator;
      this.data.sort = this.sort;
    });
  }

  applyFilter(event: Event) {
    let filterValue = (event.target as HTMLInputElement).value;
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.data.filter = filterValue;
  }

  onRepositorySelected(repositoryInfo: RepositoryInfo) {
    console.log(repositoryInfo);
    this.router.navigateByUrl('/repository-page/' + repositoryInfo.id)
  }
}
