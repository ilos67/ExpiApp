import { Component, OnInit, Input } from '@angular/core';
import { IProduct } from 'src/app/_models';

@Component({
  selector: 'app-edit-ingredient',
  templateUrl: './edit-ingredient.component.html',
  styleUrls: ['./edit-ingredient.component.scss']
})
export class EditIngredientComponent implements OnInit {
  @Input() product: IProduct;
  constructor() { }

  ngOnInit(): void {
  }

}
