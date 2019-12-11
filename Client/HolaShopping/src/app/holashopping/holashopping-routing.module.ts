import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HolashoppingComponent } from './holashopping.component';
import { ProductListComponent } from './components/public/product-list/product-list.component';

const routes: Routes = [
    {
        path: '', component: HolashoppingComponent,
        children: [
            {
                path: '',
                redirectTo: 'product-list'
            },
            {
                path: 'product-list',
                component: ProductListComponent
            },
            // { path: '404', component: NotFoundComponent },
            { path: '**', redirectTo: '404' }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HolashoppingRoutingModule { }
