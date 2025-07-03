import { createAction, props } from '@ngrx/store';
import {Category} from '../../shared/models/Category';

export const loadCategories = createAction('[Category] Load');

export const loadCategoriesSuccess = createAction(
  '[Category] Load Success',
  props<{ categories: Category[] }>()
);

export const loadCategoriesFailure = createAction(
  '[Category] Load Failure',
  props<{ error: any }>()
);
