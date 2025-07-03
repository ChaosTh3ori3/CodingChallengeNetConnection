import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {catchError, map, Observable, of} from 'rxjs';
import {Category} from '../../models/Category';
import {ReadCategoryDto} from '../../DTO´s/Category/ReadCategoryDto';
import {environment} from '../../../../../environments/environment';
import {mapper} from '../../mapping';
import {CreateCategoryDto} from '../../DTO´s/Category/CreateCategoryDto';
import {Product} from '../../models/Product';
import {ReadProductDto} from '../../DTO´s/Product/ReadProductDto';
import {CreateProductDto} from '../../DTO´s/Product/CreateProductDto';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private productsUrlSegment: string = 'products';

  constructor(
    private httpClient: HttpClient
  ) {}

  public getAllProducts$(): Observable<Product[]> {
    return this.httpClient.get<ReadProductDto[]>(environment.apiUrl + '/' + this.productsUrlSegment)
      .pipe(
        map((products) => mapper.mapArray(products, ReadProductDto, Product)),
        catchError((error) => {
          console.log(error);
          return [];
        })
      );
  }


  public getProductById$(productId: string): Observable<undefined | Product> {
    return this.httpClient
      .get<ReadProductDto>(
        environment.apiUrl + '/' + this.productsUrlSegment + '/' + productId
      )
      .pipe(
        map((product) => mapper.map(product, ReadProductDto, Product)),
        catchError((error) => {
          console.log(error)
          return of(undefined);
        })
      );
  }

  public createProduct$(
    product: CreateProductDto
  ): Observable<undefined | Category> {
    return this.httpClient
      .post(environment.apiUrl + '/' + this.productsUrlSegment, product)
      .pipe(
        map((createdProduct) =>
          mapper.map(createdProduct, ReadProductDto, Product)
        ),
        catchError((error) => {
          console.log(error);
          return of(undefined);
        })
      );
  }

  public deleteProductById(productId: string): void {
    this.httpClient
      .delete(environment.apiUrl + '/' + this.productsUrlSegment + '/' + productId)
      .pipe(
        catchError((error, caught) => {
          console.log(error);
          return of(caught);
        })
      ).subscribe();
  }
}
