import { Component, OnInit } from '@angular/core';
import {NgxGalleryAnimation, NgxGalleryImage, NgxGalleryImageSize, NgxGalleryOptions} from '@kolkov/ngx-gallery';
import { IProduct } from '../../_models'
import { ProductsService } from '../products.service';
import { ActivatedRoute} from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  product: IProduct;
  quantity = 1;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

// omitted
/**
 *
 */
constructor(private activatedRoute: ActivatedRoute, private productService: ProductsService, private bcService: BreadcrumbService,) {
  this.bcService.set('@ProductDetails', '');
}

ngOnInit() {
    this.loadProduct();
  }

  initializeGallery() {
    this.galleryOptions = [
      {
        width: '400px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageArrowsAutoHide:true,
        imageAnimation: NgxGalleryAnimation.Fade,
        imageSize: NgxGalleryImageSize.Contain,
        thumbnailSize: NgxGalleryImageSize.Contain,
        preview: false
      }
    ];
    this.galleryImages = this.getImages();
  }

  getImages() {
    const imageUrls = [];
    for (const photo of this.product.photos) {
      imageUrls.push({
        small: photo.pictureUrl,
        medium: photo.pictureUrl,
        big: photo.pictureUrl,
      });
    }
    return imageUrls;
  }

// omitted

  loadProduct() {
    this.productService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(product => {
      this.product = product;
      this.bcService.set('@ProductDetails', product.name);
      this.initializeGallery();
    }, error => {
      console.log(error);
    });
  }
}
