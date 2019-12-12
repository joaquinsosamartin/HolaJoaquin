import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HolashoppingComponent } from './holashopping.component';
import { ProductListComponent } from './components/public/product/product-list/product-list.component';
import { NotFoundComponent } from '../shared/components/error/not-found.component';

const routes: Routes = [
    {
        path: '', component: HolashoppingComponent,
        children: [
            {
                path: 'products',
                redirectTo: 'product-list'
            },
            {
                path: 'product-list',
                component: ProductListComponent
            },
            { path: '404', component: NotFoundComponent },
            { path: '**', redirectTo: '404' }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HolashoppingRoutingModule { }
