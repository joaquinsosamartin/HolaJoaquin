import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { ProductListComponentViewModel } from '../../../../models/product/product-list/productListComponentViewModel';
import { IProductService } from '../../../../services/product/iProductService';
import { ProductPagedRequest } from 'src/app/holashopping/request/productPagedRequest';
import { ProductResponse } from 'src/app/holashopping/responses/productResponse';
import { MatSnackBarConfig, MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  @Input()
  viewModel: ProductListComponentViewModel;

// TODO: translations pending

  getErrorMessage = 'Error al obtener los productos';
  closeText = 'Error';

  constructor(
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private productService: IProductService) {

  }

  ngOnInit() {
    this.getProductsPaged();

  }

  getProductsPaged() {

    const requestFilter = new ProductPagedRequest();
    requestFilter.maximumRows = 2;
    requestFilter.startRowIndex = 0;

    this.productService.getAllPaged(requestFilter)
      .subscribe((response: ProductResponse) => {
        if (response !== null && response) {
          this.viewModel.products = response.result;
        }
      }, (error: any) => {
        this.showGetProductsError();
      });
  }

  showGetProductsError() {
    const config = new MatSnackBarConfig();
    config.duration = 3000;
    const snackBarRef = this.snackBar.open(this.getErrorMessage, this.closeText, config);
  }

}
