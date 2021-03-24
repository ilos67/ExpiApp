import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  account = this.accountService.accountValue;

    constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

}
