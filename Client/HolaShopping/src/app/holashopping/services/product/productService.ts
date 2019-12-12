import { Observable, of } from 'rxjs';
import { BaseService } from '../../../shared/services/baseService';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, retry, tap } from 'rxjs/operators';
import { IProductService } from './iProductService';
import { ProductResponse } from '../../responses/productResponse';
import { ProductPagedRequest } from '../../request/productPagedRequest';

@Injectable()
export class ProductService extends BaseService implements IProductService {

    constructor(private httpClient: HttpClient) {
        super();

    }

    getAllPaged(viewModel: ProductPagedRequest): Observable<ProductResponse> {
        const url = this.baseUrl + 'product/getallpaged';
        return this.httpClient.post<ProductResponse>(url, viewModel).pipe(
            tap(() => console.log(url)),
            retry(3),
            catchError(err => {
                console.log(err);
                return of(null);
            })
        );
    }
}
