import { Component } from '@angular/core';
import { AccountInfo } from 'src/app/models/AccountInfo';
import { AccountInfoService } from 'src/app/services/account-info.service';

@Component({
  selector: 'app-account-info',
  templateUrl: './account-info.component.html',
  styleUrls: ['./account-info.component.css']
})
export class AccountInfoComponent {

  accountInfo: AccountInfo;

  constructor(private _accountInfoService: AccountInfoService) {
  }

  ngOnInit() {
    this._accountInfoService.getAccountInfo().subscribe(response => {
      this.accountInfo = response;
      console.log(response);
    });
  }
}
