import { createReducer, on } from '@ngrx/store';
import {Category} from '../../shared/models/Category';
import {loadCategories, loadCategoriesFailure, loadCategoriesSuccess} from './categories.action';

export interface CategoryState {
  categories: Category[];
  loading: boolean;
  error: any;
}

export const initialState: CategoryState = {
  categories: [],
  loading: false,
  error: null,
};

export const categoryReducer = createReducer(
  initialState,
  on(loadCategories, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(loadCategoriesSuccess, (state, { categories }) => ({
    ...state,
    categories,
    loading: false,
  })),
  on(loadCategoriesFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  }))
);
