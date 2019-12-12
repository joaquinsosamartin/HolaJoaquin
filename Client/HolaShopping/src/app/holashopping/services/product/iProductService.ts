import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductResponse } from '../../responses/productResponse';
import { ProductPagedRequest } from '../../request/productPagedRequest';

@Injectable()
export abstract class IProductService {
    abstract getAllPaged(viewModel: ProductPagedRequest): Observable<ProductResponse>;
}
