import { IIngredient } from "./ingredient";

export interface IIngredientPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IIngredient[];
  }
  export class IngredientPagination implements IIngredientPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IIngredient[] = [];
}