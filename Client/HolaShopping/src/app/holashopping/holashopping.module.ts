import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HolashoppingRoutingModule } from './holashopping-routing.module';
import { HolashoppingComponent } from './holashopping.component';
// import { HeaderComponent, NotFoundComponent, SidebarComponent } from '../shared';
import { MaterialModule } from '../material.module';
import { ProductListComponent } from './components/public/product-list/product-list.component';

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
        // NotFoundComponent,
        HolashoppingComponent,
        ProductListComponent,
        // HeaderComponent,
        // SidebarComponent,
    ],
    exports: [
    ],
    providers: [
        // { provide: ITechnologyService, useClass: TechnologyService },
        // MasterViewModelResolver
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class HolashoppingModule { }
