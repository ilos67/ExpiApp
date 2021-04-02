import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/_services/account.service';
import { Account, Role } from '../../_models';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  Role = Role;
  account: Account;
  constructor(private accountService: AccountService, private toastrService: ToastrService) { }

  ngOnInit(): void {
this.accountService.account.subscribe(x => this.account = x);
  }
  logout() {
    this.accountService.logout();
    this.toastrService.success('Great Job!!!')
}

}
