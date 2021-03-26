import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand, IProduct, IType } from 'src/app/_models';
import { ProductParams } from 'src/app/_models/productParams';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  productParams: ProductParams;
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];

  constructor(private productService: ProductsService) {
    this.productParams = this.productService.getProductParams();
  }

  ngOnInit() {
    this.getProducts(true);
    this.getBrands();
    this.getTypes();
  }

  getProducts(useCache = false) {
    this.productService.getProducts(useCache).subscribe(response => {
      this.products = response.data;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getBrands() {
    this.productService.getBrands().subscribe(response => {
      this.brands = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  getTypes() {
    this.productService.getTypes().subscribe(response => {
      this.types = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  onBrandSelected(brandId: number) {
    const params = this.productService.getProductParams();
    params.brandId = brandId;
    params.pageNumber = 1;
    this.productService.setProductParams(params);
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    const params = this.productService.getProductParams();
    params.typeId = typeId;
    params.pageNumber = 1;
    this.productService.setProductParams(params);
    this.getProducts();
  }

  onSortSelected(sort: string) {
    const params = this.productService.getProductParams();
    params.sort = sort;
    this.productService.setProductParams(params);
    this.getProducts();
  }

  onPageChanged(event: any) {
    const params = this.productService.getProductParams();
    if (params.pageNumber !== event) {
      params.pageNumber = event;
      this.productService.setProductParams(params);
      this.getProducts(true);
    }
  }

  onSearch() {
    const params = this.productService.getProductParams();
    params.search = this.searchTerm.nativeElement.value;
    params.pageNumber = 1;
    this.productService.setProductParams(params);
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.productParams = new ProductParams();
    this.productService.setProductParams(this.productParams);
    this.getProducts();
  }
}

