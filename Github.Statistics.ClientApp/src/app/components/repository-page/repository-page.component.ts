import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RepositoryStatistics } from 'src/app/models/RepositoryStatistics';
import { RepositoryInfoService } from 'src/app/services/repository-info.service';

@Component({
  selector: 'app-repository-page',
  templateUrl: './repository-page.component.html',
  styleUrls: ['./repository-page.component.css']
})
export class RepositoryPageComponent {

  basicData: any;
  basicOptions: any;
  repositoryStatistics: RepositoryStatistics;
  
  constructor(private repositoryInfoService: RepositoryInfoService, private activatedRoute: ActivatedRoute) {
  }

  ngOnInit() {
    const repositoryId = this.activatedRoute.snapshot.paramMap.get('id') ?? '';
    this.repositoryInfoService.getRepository(repositoryId).subscribe(response => {
      this.repositoryStatistics = response;
    });
  }
}
