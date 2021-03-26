import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IBrand, IProduct, IType } from '../_models';
import { IProductPagination, ProductPagination } from '../_models/productPagination';
import { ProductParams } from '../_models/productParams';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl = environment.basicUrl;
  products: IProduct[] = [];
  brands: IBrand[] = [];
  types: IType[] = [];
  pagination = new ProductPagination();
  productParams = new ProductParams();

  constructor(private http: HttpClient) { }

  getProducts(useCache: boolean) {
    if (useCache === false) {
      this.products = [];
    }

    if (this.products.length > 0 && useCache === true) {
      const pagesReceived = Math.ceil(this.products.length / this.productParams.pageSize);

      if (this.productParams.pageNumber <= pagesReceived) {
        this.pagination.data =
          this.products.slice((this.productParams.pageNumber - 1) * this.productParams.pageSize,
            this.productParams.pageNumber * this.productParams.pageSize);

        return of(this.pagination);
      }
    }

    let params = new HttpParams();

    if (this.productParams.brandId !== 0) {
      params = params.append('brandId', this.productParams.brandId.toString());
    }

    if (this.productParams.typeId !== 0) {
      params = params.append('typeId', this.productParams.typeId.toString());
    }

    if (this.productParams.search) {
      params = params.append('search', this.productParams.search);
    }

    params = params.append('sort', this.productParams.sort);
    params = params.append('pageIndex', this.productParams.pageNumber.toString());
    params = params.append('pageSize', this.productParams.pageSize.toString());

    return this.http.get<IProductPagination>(this.baseUrl + 'products', { observe: 'response', params })
      .pipe(
        map(response => {
          this.products = [...this.products, ...response.body.data];
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }

  getProductParams() {
    return this.productParams;
  }

  setProductParams(params: ProductParams) {
    this.productParams = params;
  }

  getProduct(id: number) {
    const product = this.products.find(p => p.id === id);

    if (product) {
      return of(product);
    }

    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }

  getBrands() {
    if (this.brands.length > 0) {
      return of(this.brands);
    }
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands').pipe(
      map(response => {
        this.brands = response;
        return response;
      })
    );
  }

  getTypes() {
    if (this.types.length > 0) {
      return of(this.types);
    }
    return this.http.get<IType[]>(this.baseUrl + 'products/types').pipe(
      map(response => {
        this.types = response;
        return response;
      })
    );
  }
}
