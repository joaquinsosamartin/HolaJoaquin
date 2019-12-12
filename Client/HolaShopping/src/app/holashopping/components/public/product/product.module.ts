import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductRoutes } from './product.routing';
import { ProductComponent } from './product.component';
import { ProductListComponent } from './product-list/product-list.component';

@NgModule({
  declarations: [
    ProductComponent,
    ProductListComponent
  ],
  imports: [
    ProductRoutes,
    CommonModule
  ]
})
export class ProductModule { }
