import { createFeatureSelector, createSelector } from '@ngrx/store';
import { CategoryState } from './categories.reducer';

export const selectCategoryState = createFeatureSelector<CategoryState>('categories');

export const selectAllCategories = createSelector(
  selectCategoryState,
  (state) => state.categories
);
