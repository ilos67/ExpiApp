import { Component } from '@angular/core';
import { Role, Account } from './_models';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  Role = Role;
  account: Account;

  constructor(private accountService: AccountService) {
      this.accountService.account.subscribe(x => this.account = x);
  }

  logout() {
      this.accountService.logout();
      console.log(this.accountService.accountValue);
      
      console.log(this.account);
  }
}
