import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { AccountService } from 'src/app/_services/account.service';
import { Account, IBasket, Role } from '../../_models';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  basket$: Observable<IBasket>;
  Role = Role;
  account: Account;
  constructor(private accountService: AccountService, private toastrService: ToastrService, private basketService: BasketService ) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
this.accountService.account.subscribe(x => this.account = x);
  }
  logout() {
    this.accountService.logout();
    this.toastrService.success('Great Job!!!')
}

}
