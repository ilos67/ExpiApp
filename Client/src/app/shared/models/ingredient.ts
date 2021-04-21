export interface IIngredient {
    id: number;
    name: string;
    price: number;
}

export interface IIngredientToCreate {
    name: string;
    price: number;
  }
  
export class IngredientFormValues implements IIngredientToCreate {
    name = '';
    price = 0;
  
    constructor(init?: IngredientFormValues) {
      Object.assign(this, init);
    }
  }
