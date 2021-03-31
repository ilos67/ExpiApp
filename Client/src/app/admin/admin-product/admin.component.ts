import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/products/products.service';
import { IProduct } from 'src/app/_models';
import { ProductParams } from 'src/app/_models/productParams';
import { AdminService } from './admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  products: IProduct[];
  totalCount: number;
  productParams: ProductParams;

  constructor(private productService: ProductsService, private adminService: AdminService) {
    this.productParams = this.productService.getProductParams();
  }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(useCache = false) {
    this.productService.getProducts(useCache).subscribe(response => {
      this.products = response.data;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  onPageChanged(event: any) {
    const params = this.productService.getProductParams();
    if (params.pageNumber !== event) {
      params.pageNumber = event;
      this.productService.setProductParams(params);
      this.getProducts(true);
    }
  }

  deleteProduct(id: number) {
    this.adminService.deleteProduct(id).subscribe((response: any) => {
      this.products.splice(this.products.findIndex(p => p.id === id), 1);
      this.totalCount--;
    });
  }
}