import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HolashoppingRoutingModule } from './holashopping-routing.module';
import { HolashoppingComponent } from './holashopping.component';
import { MaterialModule } from '../material.module';
import { ProductListComponent } from './components/public/product/product-list/product-list.component';
import { HeaderComponent } from '../shared/components/header/header.component';
import { NotFoundComponent } from '../shared/components/error/not-found.component';
import { IProductService } from './services/product/iProductService';
import { ProductService } from './services/product/productService';

@NgModule({
    imports: [
        CommonModule,
        HolashoppingRoutingModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule
    ],
    declarations: [
        NotFoundComponent,
        HolashoppingComponent,
        ProductListComponent,
        HeaderComponent,
    ],
    exports: [
    ],
    providers: [
        {provide: IProductService, useClass: ProductService}
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class HolashoppingModule { }
