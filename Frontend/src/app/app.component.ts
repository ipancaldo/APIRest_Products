import { Component } from '@angular/core';
import { ProductsService } from './services/products.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'tp10';

  public products: Array<any> = [];

  constructor(private productsService: ProductsService) {
    this.productsService.getProducts().subscribe((prod: any) => {
      this.products = prod;
    });
  }
}
