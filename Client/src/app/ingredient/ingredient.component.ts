import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IIngredient } from '../shared/models/ingredient';
import { IngredientParams } from '../shared/models/ingredientParams';
import { IngredientService } from './ingredient.service';

@Component({
  selector: 'app-ingredient',
  templateUrl: './ingredient.component.html',
  styleUrls: ['./ingredient.component.scss']
})
export class IngredientComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  ingredients: IIngredient[];
  ingredientParams: IngredientParams;
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];

  constructor(private ingredientService: IngredientService) {
    this.ingredientParams = this.ingredientService.getIngredientParams();
  }

  ngOnInit() {
    this.getIngredients(true);
  }

  getIngredients(useCache = false) {
    this.ingredientService.getIngredients(useCache).subscribe(response => {
      this.ingredients = response.data;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
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

}
