import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { ProductsService } from 'src/app/products/products.service';
import { IBrand, IType, ProductFormValues, IProduct } from 'src/app/_models';
import { BreadcrumbService } from 'xng-breadcrumb';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit {
  product: IProduct;
  productFormValues: ProductFormValues;
  brands: IBrand[];
  types: IType[];

  constructor(private adminService: AdminService,
              private productService: ProductsService,
              private route: ActivatedRoute,
              private bcService: BreadcrumbService,
              private router: Router) {
    this.productFormValues = new ProductFormValues();
    this.bcService.set('@Product', '');
  }

  ngOnInit(): void {
    const brands = this.getBrands();
    const types = this.getTypes();

    forkJoin([types, brands]).subscribe(results => {
      this.types = results[0];
      this.brands = results[1];
    }, error => {
      console.log(error);
    }, () => {
      if (this.route.snapshot.url[0].path === 'edit') {
        this.loadProduct();
      }
    });
  }

  updatePrice(event: any) {
    this.product.price = event;
  }

  loadProduct() {
    this.productService.getProduct(+this.route.snapshot.paramMap.get('id')).subscribe((response: any) => {
        const productBrandId = this.brands && this.brands.find(x => x.name === response.productBrand).id;
        const productTypeId = this.types && this.types.find(x => x.name === response.productType).id;
        this.product = response;
        this.bcService.set('@Product', response.name);
        this.productFormValues = {...response, productBrandId, productTypeId};
      });
    }

  getBrands() {
    return this.productService.getBrands();
  }

  getTypes() {
    return this.productService.getTypes();
  }

  onSubmit(product: ProductFormValues) {
    if (this.route.snapshot.url[0].path === 'edit') {
      const updatedProduct = {...this.product, ...product, price: +product.price};
      this.adminService.updateProduct(updatedProduct, +this.route.snapshot.paramMap.get('id')).subscribe((response: any) => {
        this.router.navigate(['/admin']);
      });
    } else {
      const newProduct = {...product, price: +product.price};
      this.adminService.createProduct(newProduct).subscribe((response: any) => {
        this.router.navigate(['/admin']);
      });
    }
  }
}
