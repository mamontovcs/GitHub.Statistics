import { Component, OnInit, ViewChild } from '@angular/core';
import { RepositoryInfo } from '../../models/RepositoryInfo';
import { RepositoryInfoService } from '../../services/repository-info.service';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { AccountInfoService } from 'src/app/services/account-info.service';

@Component({
  selector: 'app-repositories-section',
  templateUrl: './repositories-section.component.html',
  styleUrls: ['./repositories-section.component.css']
})
export class RepositoriesSectionComponent implements OnInit {
  displayedColumns: string[] = ['Id', 'Name'];
  data: MatTableDataSource<RepositoryInfo>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private router: Router, private _repositoryInfoService: RepositoryInfoService,
    private _accountInfoService: AccountInfoService) {
  }

  token!: string | null;
  ngOnInit() {
    this.token = localStorage.getItem("AccessToken");
  }
}
