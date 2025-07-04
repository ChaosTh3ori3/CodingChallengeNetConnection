import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Category} from '../../models/Category';
import {catchError, map, Observable, of} from 'rxjs';
import {mapper} from '../../mapping';
import {ReadCategoryDto} from '../../DTO´s/Category/ReadCategoryDto';
import {environment} from '../../../../../environments/environment';
import {CreateCategoryDto} from '../../DTO´s/Category/CreateCategoryDto';
import {UpdateCategoryDto} from '../../DTO´s/Category/UpdateCategoryDto';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private categoriesUrlSegment: string = 'categories';

  constructor(
    private httpClient: HttpClient
  ) {}

  public getAllCategories$(): Observable<Category[]> {
    console.log('Fetching all categories from API');
    return this.httpClient.get<ReadCategoryDto[]>(environment.apiUrl + '/' + this.categoriesUrlSegment)
      .pipe(
        map((categories) => mapper.mapArray(categories, ReadCategoryDto, Category)),
        catchError((error) => {
          console.log(error);
          return of([]);
        })
      );
  }


  public getCategoryById$(categoryId: string): Observable<undefined | Category> {
    return this.httpClient
      .get<ReadCategoryDto>(
        environment.apiUrl + '/' + this.categoriesUrlSegment + '/' + categoryId
      )
      .pipe(
        map((category) => mapper.map(category, ReadCategoryDto, Category)),
        catchError((error) => {
          console.log(error)
          return of(undefined);
        })
      );
  }

  public createCategory$(
    category: CreateCategoryDto
  ): Observable<undefined | Category> {
    return this.httpClient
      .post(environment.apiUrl + '/' + this.categoriesUrlSegment, category)
      .pipe(
        map((createdCategory) =>
          mapper.map(createdCategory, ReadCategoryDto, Category)
        ),
        catchError((error) => {
          console.log(error);
          return of(undefined);
        })
      );
  }

  public updateCategory$(
    category: UpdateCategoryDto
  ): Observable<undefined | Category> {
    return this.httpClient
      .put(environment.apiUrl + '/' + this.categoriesUrlSegment, category)
      .pipe(
        map((updatedCategory) =>
          mapper.map(updatedCategory, ReadCategoryDto, Category)
        ),
        catchError((error) => {
          console.log(error);
          return of(undefined);
        })
      );
  }

  public deleteCategoryById$(categoryId: string): void {
    this.httpClient
      .delete(environment.apiUrl + '/' + this.categoriesUrlSegment + '/' + categoryId)
      .pipe(
        catchError((error, caught) => {
          console.log(error);
          return of(caught);
        })
      ).subscribe();
  }
}
