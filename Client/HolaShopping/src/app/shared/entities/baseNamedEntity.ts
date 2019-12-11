import { BaseEntity } from './baseEntity';

export class BaseNamedEntity<T> extends BaseEntity<T> {
    name: string;
}
