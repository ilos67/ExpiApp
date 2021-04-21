import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IIngredient } from '../shared/models/ingredient';
import { IIngredientPagination, IngredientPagination } from '../shared/models/ingredientPagination';
import { IngredientParams } from '../shared/models/ingredientParams';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {

  baseUrl = environment.basicUrl;
  ingredients: IIngredient[] = [];
  pagination = new IngredientPagination();
  ingredientParams = new IngredientParams();

  constructor(private http: HttpClient) { }

  getIngredients(useCache: boolean) {
    if (useCache === false) {
      this.ingredients = [];
    }

    if (this.ingredients.length > 0 && useCache === true) {
      const pagesReceived = Math.ceil(this.ingredients.length / this.ingredientParams.pageSize);

      if (this.ingredientParams.pageNumber <= pagesReceived) {
        this.pagination.data =
          this.ingredients.slice((this.ingredientParams.pageNumber - 1) * this.ingredientParams.pageSize,
            this.ingredientParams.pageNumber * this.ingredientParams.pageSize);

        return of(this.pagination);
      }
    }

    let params = new HttpParams();

    if (this.ingredientParams.search) {
      params = params.append('search', this.ingredientParams.search);
    }

    params = params.append('sort', this.ingredientParams.sort);
    params = params.append('pageIndex', this.ingredientParams.pageNumber.toString());
    params = params.append('pageSize', this.ingredientParams.pageSize.toString());

    return this.http.get<IIngredientPagination>(this.baseUrl + 'ingredients', { observe: 'response', params })
      .pipe(
        map(response => {
          this.ingredients = [...this.ingredients, ...response.body.data];
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }

  getIngredientParams() {
    return this.ingredientParams;
  }

  setIngredientParams(params: IngredientParams) {
    this.ingredientParams = params;
  }

  getIngredient(id: number) {
    const ingredient = this.ingredients.find(p => p.id === id);

    if (ingredient) {
      return of(ingredient);
    }

    return this.http.get<IIngredient>(this.baseUrl + 'ingredients/' + id);
  }
}
