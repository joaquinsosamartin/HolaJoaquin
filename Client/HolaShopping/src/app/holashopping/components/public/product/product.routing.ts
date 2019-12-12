import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { HolashoppingComponent } from 'src/app/holashopping/holashopping.component';
import { Routes } from '@angular/router';

export const ProductRoutes: Routes = [
	{
		path: 'products',
		children: [
			{
				path: '',
				component: HolashoppingComponent
			},
			{
				path: 'list-products',
				component: ProductListComponent
			},
			{
				path: 'product/:id',
				component: ProductDetailComponent
			}
		]
	}
];
