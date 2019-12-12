import { RequestPagedFilter } from './requestPagedFilter';

export class ProductPagedRequest extends RequestPagedFilter {
    name: string;
    size: string;
    color: string;
    reference: string;
}
