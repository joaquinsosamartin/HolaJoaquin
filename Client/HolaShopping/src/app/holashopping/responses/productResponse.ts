import { GenericApiResponse } from './genericApiResponse';
import { ProductItemViewModel } from '../models/product/product-list/productItemViewModel';

export class ProductResponse extends GenericApiResponse<Array<ProductItemViewModel>> {
}
