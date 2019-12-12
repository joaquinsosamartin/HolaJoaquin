import { Guid } from 'guid-typescript';

export class ProductItemViewModel {
    id: Guid;
    name: string;
    size: string;
    color: string;
    price: string;
    description: string;
    reference: string;
    barcode128: string;
    isActive: boolean;
    category: string;
}
