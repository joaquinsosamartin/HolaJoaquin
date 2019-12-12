import { ProductListComponentViewModel } from './product-list/productListComponentViewModel';

export class ProductViewModel {

    productListComponentViewModel: ProductListComponentViewModel;

    constructor() {
        this.productListComponentViewModel = new ProductListComponentViewModel();
    }
}
