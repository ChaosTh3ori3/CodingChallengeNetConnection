import {inject, Injectable} from '@angular/core';
import {Actions, createEffect, ofType} from '@ngrx/effects';
import {CategoryService} from '../../shared/services/categoryService/category.service';
import {loadCategories, loadCategoriesFailure, loadCategoriesSuccess} from './categories.action';
import {catchError, map, of, switchMap} from 'rxjs';
import {log} from '@angular-devkit/build-angular/src/builders/ssr-dev-server';

@Injectable()
export class CategoryEffects {
  private actions$ = inject(Actions);
  private api =  inject(CategoryService);

  loadCategories$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadCategories),
      switchMap(() =>
        this.api.getAllCategories$().pipe(
          map((categories) => loadCategoriesSuccess({ categories })),
          catchError((error) => of(loadCategoriesFailure({ error })))
        )
      )
    )
  );
}
