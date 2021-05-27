import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IngredientService } from 'src/app/ingredient/ingredient.service';
import { IIngredient } from 'src/app/shared/models/ingredient';
import { IngredientParams } from 'src/app/shared/models/ingredientParams';
import { IBasket, IBasketItem, IBasketTotals, IProduct } from 'src/app/_models';

@Component({
  selector: 'app-edit-ingredient',
  templateUrl: './edit-ingredient.component.html',
  styleUrls: ['./edit-ingredient.component.scss']
})
export class EditIngredientComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  basket$: Observable<IBasket>;
  basketTotals$: Observable<IBasketTotals>;
  @Input() ingredient: IIngredient;
  ingredients: IIngredient[];
  ingredientParams: IngredientParams;
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];
  constructor(private ingredientService: IngredientService, private basketService: BasketService) { 
    this.ingredientParams = this.ingredientService.getIngredientParams();
  }

  ngOnInit(): void {
    this.getIngredients(true);
    this.basket$ = this.basketService.basket$;
    this.basketTotals$ = this.basketService.basketTotal$;
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.ingredient);
  }

  getIngredients(useCache = false) {
    this.ingredientService.getIngredients(useCache).subscribe(response => {
      this.ingredients = response.data;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    })
  }

  onSortSelected(sort: string) {
    const params = this.ingredientService.getIngredientParams();
    params.sort = sort;
    this.ingredientService.setIngredientParams(params);
    this.getIngredients();
  }

  onPageChanged(event: any) {
    const params = this.ingredientService.getIngredientParams();
    if (params.pageNumber !== event) {
      params.pageNumber = event;
      this.ingredientService.setIngredientParams(params);
      this.getIngredients(true);
    }
  }

  onSearch() {
    const params = this.ingredientService.getIngredientParams();
    params.search = this.searchTerm.nativeElement.value;
    params.pageNumber = 1;
    this.ingredientService.setIngredientParams(params);
    this.getIngredients();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.ingredientParams = new IngredientParams();
    this.ingredientService.setIngredientParams(this.ingredientParams);
    this.getIngredients();
  }

  removeBasketItem(item: IBasketItem) {
    this.basketService.removeItemFromBasket(item);
  }

  incrementItemQuantity(item: IBasketItem) {
    this.basketService.incrementItemQuantity(item);
  }

  decrementItemQuantity(item: IBasketItem) {
    this.basketService.decrementItemQuantity(item);
  }

}
