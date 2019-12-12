import { ProductItemViewModel } from './productItemViewModel';

export class ProductListComponentViewModel {
    filter: string;
    products: ProductItemViewModel[];

    constructor() {
        this.products = [];
    }
}
