import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { IIngredient } from 'src/app/shared/models/ingredient';

@Component({
  selector: 'app-ingredient-item',
  templateUrl: './ingredient-item.component.html',
  styleUrls: ['./ingredient-item.component.scss']
})
export class IngredientItemComponent implements OnInit {
  @Input() ingredient: IIngredient;
  constructor(private basketService: BasketService) { }

  ngOnInit() {
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.ingredient);
  }
}
