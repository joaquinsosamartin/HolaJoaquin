import { BaseEntity } from 'src/app/shared/entities/baseEntity';
import { Guid } from 'guid-typescript';

export class Product extends BaseEntity<Guid> {
    size: string;
    color: string;
    price: string;
    description: string;
    reference: string;
    barcode128: string;
    isActive: boolean;
    category: string;
}
